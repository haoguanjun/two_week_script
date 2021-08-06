using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class ArrayInterpreter
    {
        public ArrayParser Parser { get; private set; }
        public IEnvironment Environment { get; private set; }
        public ArrayInterpreter()
        {
            Parser = new ArrayParser();
            Natives natives = new Natives();
            NestedEnv env = new NestedEnv();
            Environment = natives.SetEnvironment(env);
        }

        public object Run(ILexer lexer)
        {
            object result = null;
            while (lexer.Peek(0) != Token.EOF)
            {
                ASTree node = Parser.Parse(lexer);
                if (!(node is NullStmnt))
                {
                    result = node.Eval(Environment);
                    Console.WriteLine($"=> {result}");
                }
            }
            return result;
        }
    }
}
