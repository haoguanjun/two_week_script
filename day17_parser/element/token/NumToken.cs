using System;
using System.Collections.Generic;

namespace week2.element.token
{
    public class NumToken : AToken
    {
        public NumToken(Type type) : base(type) { }
        public override bool Test(Token token)
        {
            return token.IsNumber;
        }
    }
}