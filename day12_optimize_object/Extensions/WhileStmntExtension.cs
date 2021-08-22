using System;
using week2;

namespace week2
{
    public static class WhileStmntExtension
    {
        public static object Eval(this WhileStmnt whileStmnt, IOptimizeEnvironment env)
        {
            object result = 0;
            for (; ; )
            {
                object condition = whileStmnt.Condition.Eval(env);
                if (condition is int && ((int)condition) == 0)
                {
                    return result;
                }
                else
                {
                    result = whileStmnt.Body.Eval(env);
                }
            }
        }
    }
}