using System;

public class IdToken : Token
{
    private String text;
    public IdToken(int line, String id) : base(line)
    {
        text = id;
    }
    public override bool IsIdentifier { get { return true; } }
    public override string Text { get { return text; } }
}
