using System;
using System.IO;

namespace week2
{
    public class EnvOptRunner
    {
        public void Run()
        {
            var interpreter = new EnvOptInterpreter();
            var lexer = MakeLexer();
            var result = interpreter.Run(lexer);

            Console.WriteLine($"Result: {result}");
        }

        public ILexer MakeLexer()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.AppendLine("def fib(n) {");
            builder.AppendLine("   if n < 2 {");
            builder.AppendLine("      n");
            builder.AppendLine("   } else { ");
            builder.AppendLine("      fib(n-1) + fib(n-2)");
            builder.AppendLine("   }");
            builder.AppendLine("}");
            builder.AppendLine("fib(15)");
            
            var stringReader = new StringReader(builder.ToString());
            var input = new LineNumberReader(stringReader);

            ILexer lexer = new Lexer(input);
            return lexer;
        }
    }
}
