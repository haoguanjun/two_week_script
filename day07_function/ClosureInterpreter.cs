using System;

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
                    // 定义闭包是在赋值语句中实现的
                    switch (node)
                    {
                        case BinaryExpress binaryExprType:
                            result = ProcessBinaryExpress(binaryExprType, Environment);
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

        public Object ProcessBinaryExpress(BinaryExpress binaryExpr, IEnvironment env)
        {
            Object result = null;

            // 闭包赋值处理
            // 预处理递归处理闭包定义问题
            //   存在 4 种情况
            //     1. 闭包定义语句
            //     2. 代码块
            //     3. if 语句
            //     4. while 语句
            //   对于后 3 种情况，可以继续处理 switch
            //   对于第 1 种情况，不用继续处理
            if ( binaryExpr.Right is ClosureFunction &&
                binaryExpr.Operator == "=")
            {
                ClosureFunction c = binaryExpr.Right as ClosureFunction;
                Function func = c.Eval(Environment) as Function;
                string closureName = (binaryExpr.Left as Name).NameString();
                env.Add(closureName, func);
                result = func;
            }
            else
            {
                // 继续原来的默认处理
                result = binaryExpr.Eval(env);
            }
            return result;
        }
    }
}
