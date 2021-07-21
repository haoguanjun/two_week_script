using System;

/*
 * 处理中的异常
 */
public class StoneException : Exception
{
    public StoneException(string message) : base(message) { }
    public StoneException(string message, ASTree ast) : base($"{message} {ast.Location}") { }
}