using System;
using System.IO;

public class Program 
{
    public static void Main()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        
        /*
        builder.AppendLine("even=0");
        builder.AppendLine("odd=0");
        builder.AppendLine("i=1");
        
        builder.AppendLine("while i < 20 {");
        builder.AppendLine("   if i % 2 == 0 {");
        builder.AppendLine("      even = even + 1");
        builder.AppendLine("   } else {");
        builder.AppendLine("      odd = odd + 1");
        builder.AppendLine("   }");
        builder.AppendLine("   i = i + 1");
        builder.AppendLine("}");
        builder.AppendLine(" even + odd");
        */

        builder.AppendLine("while 6 < 20 { } ");

        var stringReader = new StringReader(builder.ToString() );
        var input = new LineNumberReader(stringReader);

        week2.Lexer lexer = new week2.Lexer( input );
        week2.BasicParser parser = new week2.BasicParser();
        while( lexer.Peek(0) != week2.Token.EOF )
        {
            week2.ASTree ast = parser.Parse( lexer );
            Console.WriteLine($"=> {ast}");
        }

    }
}