using System;

namespace week2
{
    public class EolToken : Token
    {
        private String text;
        public EolToken() : base(-1)
        {
        }
        public override bool IsIdentifier { get { return true; } }
        public override string Text { get { return "EOF"; } }
    }
}