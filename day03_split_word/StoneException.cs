using System;

/*
 * 处理中的异常
 */
namespace week2
{
    public class StoneException : Exception
    {
        public StoneException(string message) : base(message) { }

    }
}
