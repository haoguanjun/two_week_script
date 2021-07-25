using System;

namespace week2
{
    public class EoFToken : Token
    {
        private String text;
        public EoFToken() : base(-1)
        {
        }
        public override bool IsIdentifier { get { return true; } }
        public override string Text { get { return "EOF"; } }
    }
}