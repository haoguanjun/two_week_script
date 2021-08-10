using System;
using week2;

namespace week2
{
    public static class BlockStmntExtension
    {
        public static object Eval(this BlockStmnt block, IOptimizeEnvironment env)
        {
            object result = 0;
            foreach (ASTree node in block)
            {
                if (!(node is NullStmnt))
                {
                    result = node.Eval(env);
                }
            }

            return result;
        }
    }
}