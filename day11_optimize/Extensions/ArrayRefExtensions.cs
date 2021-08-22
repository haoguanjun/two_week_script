using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week2.Ast;

/*
 * 取得数组中的值
 * arrayRef 代表数组的下标部分，即 [x] 部分
 * value 为实际的数组，即实际的数组整体部分
 * 实际的求值是通过使用下标访问实际的数组本身来实现的。
 */
namespace week2
{
    public static class ArrayRefExtensions
    {
        public static Object Eval(this ArrayRef arrayRef, IOptimizeEnvironment env, Object value)
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
