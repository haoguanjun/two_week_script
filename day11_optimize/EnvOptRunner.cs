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

            builder.AppendLine("a = [ 2, 3, 4 ] ");
            builder.AppendLine("Print a[1] ");
            builder.AppendLine("a[1] = 9");
            builder.AppendLine("Print  a[1] ");
            builder.AppendLine("b = [[3, 1], [4, 2]]");
            builder.AppendLine("Print b[1][0] + \": \" + b[1][1]");

            var stringReader = new StringReader(builder.ToString());
            var input = new LineNumberReader(stringReader);

            ILexer lexer = new Lexer(input);
            return lexer;
        }
    }
}
