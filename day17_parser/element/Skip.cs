using System;
using System.Collections.Generic;

/*
 * 可以跳过的 Token
 */
namespace week2.element 
{
    public class Skip: Leaf
    {
        public Skip(string[] t): base(t) { }
        protected void Finded(IList<ASTree> res, Token token) {}
    }
}