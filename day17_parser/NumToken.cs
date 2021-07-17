using System;
using System.Collections.Generic;

namespace Parser
{
    internal static class NumToken: AToken
    {
        protected NumToken(Type type): base(type) { }
        protected bool Test(Token token)
        {
            return token.IsNumber();
        }
    }
}