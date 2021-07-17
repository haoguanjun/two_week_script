using System;

//NumToken、IdToken 与 StrToken 类是 Token 类的子类。它们分别对应不同类型的单词。

public class NumToken : Token
{
    private int value;

    public NumToken(int line, int v) : base(line)
    {

        value = v;
    }
    public override bool IsNumber { get { return true; } }

    public override string Text { get { return value.ToString(); } }
    public override int Number { get { return value; } }
}
