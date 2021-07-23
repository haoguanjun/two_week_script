using System;
using System.Collections.Generic;

namespace week2
{
    public class Precedence
    {
        public int Value { private set; get; }
        public bool LeftAssoc { private set; get; }             // left aaociative
        public Precedence(int v, bool a)
        {
            Value = v;
            LeftAssoc = a;
        }

        public override string ToString()
        {
            return $"Precedence: Value->{Value}, Left->{LeftAssoc}";
        }
    }
}