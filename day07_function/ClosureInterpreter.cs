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
                    // 预处理递归处理闭包定义问题
                    //   存在 4 种情况
                    //     1. 闭包定义语句
                    //     2. 代码块
                    //     3. if 语句
                    //     4. while 语句
                    //   对于后 3 种情况，可以继续处理 switch
                    //   对于第 1 种情况，不用继续处理
                    ProcessClosureAssign(node, Environment);

                    if( IsClosureAssign( node))
                    {
                        continue;
                    }

                    // 在支持闭包的语法中，增加了三种新的语句：定义闭包，定义函数和调用函数
                    switch (node)
                    {
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

        public bool IsClosureAssign(ASTree node)
        {
            if (node is BinaryExpress b &&
               b.Operator == "=" &&
               b.Right is ClosureFunction)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ProcessClosureAssign(ASTree node, IEnvironment env)
        {
            if( node == null || node.Count == 0)
            {
                return;
            }

            // 检查赋值语句
            if( node is BinaryExpress b && 
                b.Operator == "=" &&
                b.Right is ClosureFunction)
            {
                ClosureFunction c = b.Right as ClosureFunction;
                Function func = c.Eval(Environment) as Function;
                string closureName = (b.Left as Name).NameString();
                env.Add(closureName, func);
            }

            for(int index = 0; index < node.Count; index++)
            {
                ProcessClosureAssign(node.Child(index), env);
            }
        }
    }
}
