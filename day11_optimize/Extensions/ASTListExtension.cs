using System;
using week2;

namespace week2
{
    public static class ASTListExtension
    {
        public static object Eval(this week2.ASTList list, IOptimizeEnvironment env)
        {
            throw new StoneException($"Cann't eval: {list}");
        }
    }
}