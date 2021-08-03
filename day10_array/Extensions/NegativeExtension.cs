using System;
using week2;

namespace week2
{
    public static class NegativeExprExtension
    {
        public static object Eval(this week2.NegativeExpr node, IEnvironment env)
        {
            object v = node.Operand.Eval( env );
            if( v is int)
            {
                return - (int) v;
            }
            else
            {
                throw new StoneException($"Bad type for: {node}");
            }
        }
    }
}