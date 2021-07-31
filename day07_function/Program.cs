using System;
using System.IO;
using week2;

namespace week2
{
    public class FunctionLexerRunner
    {
        public static void Main(String[] args)
        {
            var interpreter = new FunctionInterpreter();
            var lexer = MakeLexer();
            var result = interpreter.Run(lexer);

            Console.WriteLine($"Result: {result}");
        }

        public static ILexer MakeLexer()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.AppendLine("def fact (n) {");
            builder.AppendLine("   f = 1");
            builder.AppendLine("   while n > 0 {");
            builder.AppendLine("      f = f * n");
            builder.AppendLine("      n = n - 1");
            builder.AppendLine("   }");
            builder.AppendLine("   f");
            builder.AppendLine("}");
            builder.AppendLine("fact(9)");

            var stringReader = new StringReader(builder.ToString());
            var input = new LineNumberReader(stringReader);

            ILexer lexer = new Lexer(input);
            return lexer;
        }
    }
}