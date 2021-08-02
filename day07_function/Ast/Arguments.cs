using System;
using System.Collections.Generic;

namespace week2
{
    public class Arguments: Postfix
    {
        public Arguments(IList<ASTree> c): base(c) { }
        public int Size {
            get {
                return Count;
            }
        }
    }
}