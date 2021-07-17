using System;
using System.IO;

//第一个测试用例：分割单词的测试
public class LexerRunner {
    public static void Main(String[] args)  {

        var code = @"     sum = 0";
        var stringReader = new StringReader(code);
        var input = new LineNumberReader(stringReader);

        Laxer l = new Laxer( input );
        for (Token t; (t = l.Read()) != Token.EOF; )
            Console.WriteLine( "=> " + t.Text);
    }
}