using System;

/*
 * 标识符类型的标识
 */
public class IdToken : Token
{
    // 标识符对应的文本
    private String text;
    public IdToken(int line, String id) : base(line)
    {
        text = id;
    }
    public override bool IsIdentifier { get { return true; } }
    public override string Text { get { return text; } }
}
