using System;
using System.Collections.Generic;

namespace week2.element 
{
    public class Skip: Leaf
    {
        protected Skip(string[] t): base(t) { }
        protected void Finded(IList<ASTree> res, Token token) {}
    }
}