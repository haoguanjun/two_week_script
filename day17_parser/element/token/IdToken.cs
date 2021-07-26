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
        public IdToken(Type type, HashSet<string> r): base( type )
        {
            _reserved = r != null
                ? r
                : new HashSet<string>();
        }

        // 是标识，但是不是保留字：} ; 和换行
        public override bool Test(Token token)
        {
            return token.IsIdentifier && !_reserved.Contains(token.Text);
        }
    }
}