using System;
using System.Collections.Generic;

namespace Parser
{
    public class Operators: HashSet<string, Precedence>
    {
        public static bool LEFT = true;
        public static bool RIGHT = false;
        public void Add(string name, int prec, bool leftAssoc)
        {
            this.Add( name, new Precedence(prec, leftAssoc) );
        }
    }
}