using System;
public class EolToken : Token
{
    private String text;
    public EolToken() : base(-1)
    {
    }
    public new bool isIdentifier() { return true; }
    public override string Text { get { return "EOF"; } }
}