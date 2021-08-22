using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class EnvOptInterpreter
    {
        public ArrayParser Parser { get; private set; }
        public IOptimizeEnvironment Environment { get; private set; }
        public EnvOptInterpreter()
        {
            Parser = new ArrayParser();
            // 原生函数支持
            Natives natives = new Natives();
            ResizableArrayEnvironment env = new ResizableArrayEnvironment();
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
                    // 对符号进行预处理
                    node.PreProcess(Environment.Symbols);

                    result = node.Eval(Environment);
                    Console.WriteLine($"=> {result}");
                }
            }
            return result;
        }
    }
}