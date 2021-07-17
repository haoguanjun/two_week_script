using System;

namespace Parser
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