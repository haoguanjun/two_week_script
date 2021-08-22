using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week2.Ast;

/*
 * 对数组字面量进行求值
 * 例如 “[ 1, 2, 3 ]” 进行求值，得到真正的数组值 [ 1, 2, 3 ]
 */
namespace week2
{
    public static class ArrayLiteralExtensions
    {
        public static Object Eval(this ArrayLiteral arrayLiteral, IOptimizeEnvironment env)
        {
            int count = arrayLiteral.Count;
            Object[] result = new Object[count];
            for (int index = 0; index < count; index++)
            {
                ASTree item = arrayLiteral.Child(index);
                Object value = item.Eval(env);
                result[index] = value;
            }
            return result;
        }
    }
}