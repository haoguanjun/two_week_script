using System;

/*
 * 字符串类型的标记
 */
namespace week2
{
    public class StrToken : Token
    {
        private String _literal;
        public StrToken(int line, String value) : base(line)
        {
            _literal = value;
        }
        public override bool IsString { get { return true; } }
        public override string Text { get { return _literal; } }
    }
}