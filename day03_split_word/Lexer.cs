using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/*
 * https://docs.microsoft.com/zh-cn/dotnet/standard/base-types/regular-expressions
 */
public class Laxer
{
    /* 正则表达式，用于匹配单词，然后分割单词
     * 
     * \\s*                                 0 到多个空白
     * ((//.*)|([0-9]+))                    注释，或者一组数字
     * \\\\\"                               \"
     * \\\\\\\\                             \\
     * \\\\\n                               \n
     * (\"(\\\\\"|\\\\\\\\|\\\\n|[^\"])*\") 双引号处理的字符串，字符串中可能包含转义字符
     * [A-Z_a-z][A-Z_a-z0-9]*               字母开头的标识符 
     * \\|\\|                               ||
     * \\p{Punct}                           // matches any punctuation character.
     *                                      // https://www.tutorialspoint.com/javaregex/javaregex_posix_class_punct.htm
     * \\p{P}                               match all punctuation 
     * \\p{S}                               match All symbols.
     * [\\p{S}\\p{P}]
     *                                      // https://docs.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions?redirectedfrom=MSDN#supported-unicode-general-categories
     */
    public static readonly String regexPat
        = "\\s*((//.*)|([0-9]+)|(\"(\\\\\"|\\\\\\\\|\\\\\n|[^\"])*\")"
          + "|([A-Z_a-z][A-Z_a-z0-9]*)|==|<=|>=|&&|\\|\\||[\\p{S}\\p{P}])?";

    //将给定的正则表达式编译并赋予给Pattern类，Pattern是java.util.regex自带的
    private Regex pattern = new Regex(regexPat);

    //存储 语言对象（字符串、整形、标识符）
    private IList<Token> queue = new List<Token>();

    //是否有下一个
    private bool hasMore;

    //LineNumberReader是 StringReader 的子类，用来按行读取文本文件。
    private LineNumberReader reader;

    public Laxer(LineNumberReader r)
    {
        hasMore = true;
        reader = r;
    }

    //读，用于构建语法树
    public Token Read()
    {
        if (fillQueue(0))
        {
            var value = queue[0];
            queue.RemoveAt(0);
            return value;
        }
        else
        {
            return Token.EOF;
        }
    }
    public Token Peek(int i)
    {
        if (fillQueue(i))
            return queue[i];
        else
            return Token.EOF;
    }

    // 填充 语言对象的队列
    // 判断索引是否超过队列长度，如果超过，判断是否有后续可读，如果有，则读取
    private bool fillQueue(int i)
    {
        while (i >= queue.Count)
            if (hasMore)
                readLine();
            else
                return false;
        return true;
    }

    //readLine 与 addToken 是词法分析的核心部分，其他都只是起辅助作用，

    //从每一行中读取单词的方法
    protected void readLine()
    {
        string line;
        try
        {
            line = reader.ReadLine();
        }
        catch (IOException e)
        {
            throw new ParseException(e.Message);
        }

        if (line == null)
        {
            hasMore = false;
            return;
        }
        //获取行列数
        int lineNo = reader.GetLineNumber();

        //使用该 Matcher实例以编译的正则表达式为基础对目标字符串进行匹配工作，多个Matcher是可以共用一个Pattern对象的
        MatchCollection matches = pattern.Matches(line);

        foreach (Match item in matches)
        {
            if (item.Value == String.Empty)
            {
                continue;
            }

            TokenType type = TokenType.ID;
            string tokenValue = null;
            if (item.Groups[3].Success)
            {
                type = TokenType.Number;
                tokenValue = item.Groups[3].Value;
            }
            else if (item.Groups[4].Success)
            {
                type = TokenType.String;
                tokenValue = item.Groups[4].Value;
            }
            else if( item.Groups[6].Success){
                type = TokenType.ID;
                tokenValue = item.Groups[6].Value;
            }
            else
            {
                type = TokenType.ID;
                tokenValue = item.Value;
            }
            AddToken(lineNo, type, tokenValue);

        }
        queue.Add(new IdToken(lineNo, Token.EOL));
    }

    //
    protected void AddToken(int lineNo, TokenType type, string match)
    {
        Token token = null;
        if (type == TokenType.Number)
        {
            token = new NumToken(lineNo, Int32.Parse(match));
        }
        else if (type == TokenType.String)
        {
            token = new StrToken(lineNo, toStringLiteral(match));
        }
        else if (type == TokenType.ID)
        {
            token = new IdToken(lineNo, match);
        }

        queue.Add(token);
    }

    protected String toStringLiteral(String s)
    {
        StringBuilder sb = new StringBuilder();
        int len = s.Length - 1;
        for (int i = 1; i < len; i++)
        {
            char c = s[i];
            if (c == '\\' && i + 1 < len)
            {
                int c2 = s[i + 1];
                if (c2 == '"' || c2 == '\\')
                    c = s[++i];
                else if (c2 == 'n')
                {
                    ++i;
                    c = '\n';
                }
            }
            sb.Append(c);
        }
        return sb.ToString();
    }

}
