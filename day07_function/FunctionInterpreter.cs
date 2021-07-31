using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class FunctionInterpreter
    {
        public FunctionParser Parser { get; private set; }
        public IEnvironment Environment { get; private set; }
        public FunctionInterpreter()
        {
            Parser = new FunctionParser();
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
                    // 在支持函数的语法中，增加了两种新的语句：定义函数和调用函数
                    switch( node )
                    {
                        case DefStmnt defStmnType:
                            result = defStmnType.Eval(Environment);
                            break;
                        case ParameterList parameterType:
                            result = parameterType.Eval(Environment);
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
