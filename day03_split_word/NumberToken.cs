using System;


/*
 * 数值类型的标记
 */
namespace week2
{
    public class NumToken : Token
    {
        private int _value;

        public NumToken(int line, int value) : base(line)
        {

            _value = value;
        }
        public override bool IsNumber { get { return true; } }

        public override string Text { get { return _value.ToString(); } }
        public override int Number { get { return _value; } }
    }
}
