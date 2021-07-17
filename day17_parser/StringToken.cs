using System;
using System.Collections.Generic;

namespace Parser
{
    internal static class StringToken: AToken
    {
        protected StringToken(Type type): base( type) { }
        protected bool Test(Token token)
        {
            return token.IsString();
        }
    }
}