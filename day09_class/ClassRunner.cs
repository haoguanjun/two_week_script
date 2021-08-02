using System;
using System.IO;

namespace week2
{
    public class ClassRunner
    {
        public void Run()
        {
            var interpreter = new ClassInterpreter();
            var lexer = MakeLexer();
            var result = interpreter.Run(lexer);

            Console.WriteLine($"Result: {result}");
        }

        public ILexer MakeLexer()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.AppendLine("class Position {");
            builder.AppendLine("   x = 0");
            builder.AppendLine("   y = 0");
            builder.AppendLine("   def move(nx, ny) {");
            builder.AppendLine("      x = nx");
            builder.AppendLine("      y = ny");
            builder.AppendLine("   }");
            builder.AppendLine("}");
            builder.AppendLine("p = Position.new");
            builder.AppendLine("p.move(3, 4)");
            builder.AppendLine("p.x = 10");
            builder.AppendLine("Print(p.x + p.y)");

            var stringReader = new StringReader(builder.ToString());
            var input = new LineNumberReader(stringReader);

            ILexer lexer = new Lexer(input);
            return lexer;
        }
    }
}
