using System;

/*
 * 标记的基类
 * 系统中支持 3 种标记：数字，标识和字符串三种。
 */
namespace week2
{
    public abstract class Token
    {
        // 表示行结束的特殊标记
        public static readonly Token EOF = new EolToken();
        // 表示行结束的字符，Windows 中为 \r\n，Linux 中为 \n
        public static readonly String EOL = Environment.NewLine;
        protected Token(int line)
        {
            LineNumber = line;
        }

        // 标记所在的行号
        public int LineNumber { get; private set; }
        // 是否为标识符
        public virtual Boolean IsIdentifier { get; }
        // 是否为数字
        public virtual Boolean IsNumber { get; }
        // 是非为字符串
        public virtual Boolean IsString { get; }
        // 如果为数字标记，其对应的实际数值
        public virtual int Number { get; }
        // 对于标识符和字符串来说，都是文本
        public virtual string Text { get; }
    }
}