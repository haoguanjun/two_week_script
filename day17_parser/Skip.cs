using System;
using System.Collections.Generic;

namespace Parser 
{
    internal static class Skip: Leaf
    {
        protected Skip(string[] t): base(t) { }
        protected void Finded(IList<ASTree> res, Token token) {}
    }
}