using System;
using System.IO;
using week2;

namespace week2
{
    public class LexerRunner
    {
        public static void Main(String[] args)
        {
            var parser = new BasicParser();
            var environment = new week2.BasicEnv();
            Run(parser, environment);
        }

        public static void Run(BasicParser parser, IEnvironment env)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.AppendLine("sum=99");
            builder.AppendLine("sum");

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