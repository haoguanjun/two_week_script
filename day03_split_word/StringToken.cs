using System;
public class StrToken : Token
{
    private String literal;
    public StrToken(int line, String str) : base(line)
    {
        literal = str;
    }
    public override bool IsString { get { return true; } }
    public override string Text { get { return literal; } }
}