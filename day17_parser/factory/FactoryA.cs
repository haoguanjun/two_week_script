using System;
using System.Collections.Generic;

namespace week2.factory
{
    internal class FactoryA: Factory
    {
        protected ASTree Make0(Object arg)
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