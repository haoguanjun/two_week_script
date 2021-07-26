using System;
using System.IO;
using week2;

//第一个测试用例：分割单词的测试
public class LexerRunner {
    public static void Main(String[] args)  {
        var code = "while i < 2 { }";
        Console.WriteLine(code);
        
        var stringReader = new StringReader(code);
        var input = new LineNumberReader(stringReader);

        Lexer l = new Lexer( input );
        for (Token t; (t = l.Read()) != Token.EOF; )
            Console.WriteLine( $"Line: {t.LineNumber}, Type: {t.GetType()}, Literial: {t.Text}, Length: {t.Text.Length}");
    }
}