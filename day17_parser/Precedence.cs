using System;
using System.Collections.Generic;

namespace week2
{
    public class Precedence
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