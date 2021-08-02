using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public static class PrimaryExpressionExtension
    {
        public static object Eval( this PrimaryExpr primary, IEnvironment environment)
        {
            return EvalSubExpression( primary, environment, 0);
        }

        public static object EvalSubExpression(PrimaryExpr primary, IEnvironment environment, int nest)
        {
            if( HasPostfix(primary, nest))
            {
                Object target = EvalSubExpression(primary, environment, nest + 1);
                Postfix postfix = Postfix(primary, nest);
                object result = null;
                switch (postfix)
                {
                    case Arguments arguments:
                        result = arguments.Eval(environment, target);
                        break;
                }
                return result;
            }
            else
            {
                ASTree node = Operator(primary);
                return node.Eval(environment);
            }
        }

        // 获取函数名称
        public static ASTree Operator(PrimaryExpr primary)
        {
            return primary.Child(0);
        }

        public static bool HasPostfix(PrimaryExpr primary, int next)
        {
            return primary.Count - next > 1;
        }

        // 获取后缀
        public static Postfix Postfix(PrimaryExpr primary, int next)
        {
            int index = primary.Count - next - 1;
            return primary.Child(index) as Postfix;
        }


    }
}
