using System;

namespace Parser
{
    internal class ParseException: Exception
    {
        internal ParseException(Token token)
        {

        }

        internal ParseException(string message, Token token)
        {
            
        }
    }
}