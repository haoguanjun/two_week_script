using System;
using week2;

public class ParseException : Exception
{
    public ParseException(string message) : base(message) { }

    public ParseException(Token token) : base(token.Text) { }

    public ParseException(string message, Token token) : base( $"Message: {message}, Token: {token.Text}" ) { }
}