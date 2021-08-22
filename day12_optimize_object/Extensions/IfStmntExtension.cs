using System;
using week2;

namespace week2
{
    public static class IfStmntExtension
    {
        public static object Eval(this IfStmnt ifStmnt, IOptimizeEnvironment env)
        {
            object condition = ifStmnt.Condition.Eval(env);
            if (condition is int &&
                ((int)condition != 0))
            {
                return ifStmnt.ThenBlock.Eval(env);
            }
            else
            {
                ASTree elseBlock = ifStmnt.ElseBlock;
                if (elseBlock == null)
                {
                    return 0;
                }
                else
                {
                    return elseBlock.Eval(env);
                }
            }
        }

    }
}