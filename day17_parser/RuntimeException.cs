using System;

namespace week2
{
    public class RuntimeException: Exception
    {
        private Exception _innerException;
        public RuntimeException(Exception exception)
        {
            _innerException = exception;
        }
    }
}