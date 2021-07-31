using System;
using System.IO;

namespace week2
{
    public class NativeRunner
    {
        public void Run()
        {
            var interpreter = new NativeInterpreter();
            var lexer = MakeLexer();
            var result = interpreter.Run(lexer);

            Console.WriteLine($"Result: {result}");
        }

        public ILexer MakeLexer()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.AppendLine("inc = function(x) { x + 1 }");
            builder.AppendLine("result = inc(3)");
            builder.AppendLine("Print(result)");

            var stringReader = new StringReader(builder.ToString());
            var input = new LineNumberReader(stringReader);

            ILexer lexer = new Lexer(input);
            return lexer;
        }
    }
}
