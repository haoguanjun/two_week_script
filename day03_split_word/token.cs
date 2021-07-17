using System;

public abstract class Token
{
    public static readonly Token EOF = new EolToken();
    public static readonly String EOL = Environment.NewLine;
    private int lineNumber;

    protected Token(int line)
    {
        lineNumber = line;
    }

    public int LineNumber { get; }
    public virtual Boolean IsIdentifier { get;  }
    public virtual Boolean IsNumber { get;  }
    public virtual Boolean IsString { get; }
    public virtual int Number { get;  }
    public virtual string Text { get; }
}