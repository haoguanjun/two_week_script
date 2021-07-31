using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class ClosureInterpreter
    {
        public ClosureParser Parser { get; private set; }
        public IEnvironment Environment { get; private set; }
        public ClosureInterpreter()
        {
            Parser = new ClosureParser();
            Environment = new NestedEnv();
        }

        public object Run(ILexer lexer)
        {
            object result = null;
            while (lexer.Peek(0) != Token.EOF)
            {
                ASTree node = Parser.Parse(lexer);
                if (!(node is NullStmnt))
                {
                    // 在支持闭包的语法中，增加了三种新的语句：定义闭包，定义函数和调用函数
                    switch (node)
                    {
                        case ClosureFunction closureType:
                            result = closureType.Eval(Environment);
                            break;
                        case DefStmnt defStmnType:
                            result = defStmnType.Eval(Environment);
                            break;

                        case PrimaryExpr primaryExprType:
                            result = primaryExprType.Eval(Environment);
                            break;

                        default:
                            result = node.Eval(Environment);
                            break;
                    }

                    Console.WriteLine($"=> {result}");
                }
            }

            return result;
        }
    }
}
