using System;
using System.Collections.Generic;

namespace week2.element.token
{
    public class StringToken : AToken
    {
        public StringToken(Type type) : base(type) { }
        public bool Test(Token token)
        {
            return token.IsString;
        }
    }
}