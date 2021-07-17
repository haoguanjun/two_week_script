using System;
using System.Collections.Generic;

namespace Parser
{
    internal static class Precedence
    {
        int _value;
        bool _leftAssoc;             // left aaociative
        public Precedence(int v, bool a)
        {
            _value = v;
            _leftAssoc = a;
        }
    }
}