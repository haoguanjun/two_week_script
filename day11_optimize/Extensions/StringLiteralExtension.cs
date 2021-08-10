using System;
using week2;

namespace week2
{
    public static class StringLiteralExtension
    {
        public static object Eval(this week2.StringLiteral token, IOptimizeEnvironment env)
        {
            return token.Value;
        }
    }
}