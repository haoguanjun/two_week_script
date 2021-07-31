using System;
using System.IO;

namespace week2
{
    public class FunctionRunner
    {
        public void Run()
        {
            RunFunction();
        }

        public void RunFunction()
        {
            var interpreter = new FunctionInterpreter();
            var lexer = MakeLexer();
            var result = interpreter.Run(lexer);

            Console.WriteLine($"Result: {result}");
        }

        public ILexer MakeLexer()
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
