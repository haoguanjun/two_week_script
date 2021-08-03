using System;
using week2;

namespace week2
{
    public static class NumberLiteralExtension
    {
        public static object Eval(this NumberLiteral token, IEnvironment env)
        {
            return token.Value();
        }
    }
}