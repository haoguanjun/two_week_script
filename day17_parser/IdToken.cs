using System;
using System.Collections.Generic;

namespace Parser
{
    internal static class IdToken: AToken
    {
        HashSet<string> _reserved;
        protected IdToken(Type type, HashSet<string> r)
        {
            base( type );
            _reserved = r != null
                ? r
                : new HashSet<string>();
        }

        protected bool Test(Token token)
        {
            token.IsIdentifier() && ! _reserved.Contains(token.Text);
        }
    }
}