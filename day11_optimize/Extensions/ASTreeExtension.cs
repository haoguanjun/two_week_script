using System;
using week2;
using week2.Ast;

namespace week2
{
    public static class ASTreeExtension
    {
        public static object Eval(this week2.ASTree node, IEnvironment env)
        {
            object result = null;
            // 使用类型模式匹配
            // https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/switch#type-pattern
            switch (node)
            {
                // array
                case ArrayLiteral arrayLiteral:
                    result = arrayLiteral.Eval(env);
                    break;

                // class
                case ClassStmnt classType:
                    result = classType.Eval(env);
                    break;
                case ClassBody classBody:
                    result = classBody.Eval(env);
                    break;

                // 在支持闭包的语法中，增加了三种新的语句：定义闭包，定义函数和调用函数
                // 定义闭包是在赋值语句中实现的
                case ClosureFunction closureType:
                    result = closureType.Eval(env);
                    break;

                // 在支持函数的语法中，增加了两种新的语句：定义函数和调用函数
                case DefStmnt defStmnType:
                    result = defStmnType.Eval(env);
                    break;
                case PrimaryExpr primaryExprType:
                    result = primaryExprType.Eval(env);
                    break;

                // 
                case NumberLiteral numberType:
                    result = numberType.Eval(env);
                    break;
                case Name nameType:
                    result = nameType.Eval(env);
                    break;
                case StringLiteral stringType:
                    result = stringType.Eval(env);
                    break;
                case NegativeExpr negativeType:
                    result = negativeType.Eval(env);
                    break;
                case BinaryExpress binaryExprssType:
                    result = binaryExprssType.Eval(env);
                    break;
                case BlockStmnt blockType:
                    result = blockType.Eval(env);
                    break;
                case IfStmnt ifType:
                    result = ifType.Eval(env);
                    break;
                case WhileStmnt whileType:
                    result = whileType.Eval(env);
                    break;

                // 不是特殊语句的处理
                case ASTList listType:
                    result = listType.Eval(env);
                    break;
                case ASTLeaf leafType:
                    result = leafType.Eval(env);
                    break;
            }

            return result;
        }
    }
}