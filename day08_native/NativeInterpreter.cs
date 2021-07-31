using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class NativeInterpreter
    {
        public ClosureParser Parser { get; private set; }
        public IEnvironment Environment { get; private set; }
        public NativeInterpreter()
        {
            Parser = new ClosureParser();
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
                    // 预处理递归处理闭包定义问题
                    //   存在 4 种情况
                    //     1. 闭包定义语句
                    //     2. 代码块
                    //     3. if 语句
                    //     4. while 语句
                    //   对于后 3 种情况，可以继续处理 switch
                    //   对于第 1 种情况，不用继续处理
                    ProcessClosureAssign(node, Environment);

                    if (IsClosureAssign(node))
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
            if (node == null || node.Count == 0)
            {
                return;
            }

            // 检查赋值语句
            if (node is BinaryExpress b &&
                b.Operator == "=" &&
                b.Right is ClosureFunction)
            {
                ClosureFunction c = b.Right as ClosureFunction;
                Function func = c.Eval(Environment) as Function;
                string closureName = (b.Left as Name).NameString();
                env.Add(closureName, func);
            }

            // 表达式赋值
            if (node is BinaryExpress p &&
                p.Operator == "=" &&
                p.Right is PrimaryExpr)
            {
                PrimaryExpr c = p.Right as PrimaryExpr;
                Object result = c.Eval(Environment);
                string name = (p.Left as Name).NameString();
                env.Add(name, result);
            }

            for (int index = 0; index < node.Count; index++)
            {
                ProcessClosureAssign(node.Child(index), env);
            }
        }

        public object ProcessNativeFunction(ASTree node, IEnvironment env)
        {
            object result = null;

            if ( node is PrimaryExpr &&
                node.Child(0) is Name &&
                node.Child(1) is Arguments)
            {
                Name nameNode = node.Child(0) as Name;
                string methodName = nameNode.NameString();
                Object func = env.Get(methodName);
                Arguments args = node.Child(1) as Arguments;

                switch( func)
                {
                    case NativeFunction nativeFunc:
                        result = args.EvalWithNative(env, nativeFunc);
                        break;
                    case Function basicFunc:
                        result = args.BasicEval(env, basicFunc);
                        break;
                }
            }
            else
            {

            }

            return result;
        }
    }
}
