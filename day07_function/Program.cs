using System;
using System.IO;
using week2;

namespace week2
{
    public class FunctionLexerRunner
    {
        public static void Main(String[] args)
        {
            var parser = new FunctionParser();
            var environment = new week2.BasicEnv();
            Run(parser, environment);
        }

        public static void Run(FunctionParser parser, IEnvironment env)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

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

            var stringReader = new StringReader(builder.ToString());
            var input = new LineNumberReader(stringReader);

            Lexer lexer = new Lexer(input);
            while (lexer.Peek(0) != Token.EOF)
            {
                ASTree node = parser.Parse(lexer);
                if (!(node is NullStmnt))
                {
                    object result = node.Eval(env);
                    Console.WriteLine($"=> {result}");
                }
            }
        }
    }
}