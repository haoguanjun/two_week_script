using System;
using System.Collections.Generic;

/*
 * 接收一个列表类型参数
 *     如果列表中只有一个对象，直接返回该对象
 *     否则将列表重新包装为一个 ASTList 对象
 */
namespace week2.factory
{
    public class FactoryA: Factory
    {
        public override ASTree Make0(Object arg)
        {
            IList<ASTree> results = arg as IList<ASTree>;
            if(results.Count == 1)
            {
                return results[0];
            }
            else
            {
                return new ASTList(results);
            }
        }
    }
}