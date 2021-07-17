using System;
using System.Text;

namespace weeks2.day15
{
    public class Laxer
    {
        private static readonly int EMPTY = -1;
        private int lastChar = Laxer.EMPTY;
        private System.IO.TextReader _reader;

        public Laxer(System.IO.TextReader reader)
        {
            _reader = reader;
        }
        private int GetChar()
        {
            if (lastChar == EMPTY)
            {
                return _reader.Read();
            }
            else
            {
                int c = lastChar;
                lastChar = EMPTY;
                return c;
            }
        }

        private void UngetChar(int c)
        {
            lastChar = c;
        }

        /*
         * 每次调用返回一个字符串形式的 token
         * 1. 数字
         * 2. 标识
         * 3. =
         * 4. ==
         */
        public string Read()
        {
            StringBuilder builder = new StringBuilder();
            int c;
            do
            {
                c = GetChar();
            } while (IsSpace(c));

            if (c < 0)
            {
                return null;
            }
            else if (IsDigit(c))
            {
                do
                {
                    builder.Append((char)c);
                    c = GetChar();
                } while (IsDigit(c));
            }
            else if (IsLetter(c))
            {
                do
                {
                    builder.Append((char)c);
                    c = GetChar();
                } while (IsLetter(c) || IsDigit(c));
            }
            else if (c == '=')
            {
                c = GetChar();
                if (c == '=')
                {
                    return "==";
                }
                else
                {
                    UngetChar(c);
                    return "=";
                }
            }
            else
            {
                throw new Exception("Invalid charactor");
            }

            if (c >= 0)
            {
                UngetChar(c);
            }

            return builder.ToString();
        }

        // utility
        public static bool IsSpace(int c)
        {
            return c == ' ' || c == '\t';
        }
        public static bool IsLetter(int c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }
        public static bool IsDigit(int c)
        {
            return c >= '0' && c <= '9';
        }
    }
}
