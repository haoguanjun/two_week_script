using System;
using System.Collections.Generic;

/*
 * 处理 Id Token
 */
namespace week2.element.token
{
    public class IdToken : AToken
    {
        HashSet<string> _reserved;
        public IdToken(Type type, HashSet<string> r)
        {
            base(type);
            _reserved = r != null
                ? r
                : new HashSet<string>();
        }

        public bool Test(Token token)
        {
            token.IsIdentifier() && !_reserved.Contains(token.Text);
        }
    }
}