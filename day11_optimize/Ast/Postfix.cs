using System;
using System.Collections.Generic;

namespace week2
{
    public abstract class Postfix: ASTList
    {
        public Postfix(IList<ASTree> list): base( list) { }
    }
}