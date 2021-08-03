using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week2.Ast;

/*
 * 取得数组中的值
 * arrayRef 代表数组中的下标
 * value 为实际的数组
 */
namespace week2
{
    public static class ArrayRefExtensions
    {
        public static Object Eval(this ArrayRef arrayRef, IEnvironment env, Object value)
        {
            if(value is Object[] array)
            {
                ASTree indexItem = arrayRef.Index;
                // 求得实际的下标值
                Object index = indexItem.Eval(env);
                if( index is Int32 intIndex)
                {
                    return array[intIndex];
                }
            }
            throw new StoneException($"bad array access.");
        }
    }
}
