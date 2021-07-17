using System;
using System.IO;

/*
 * 支持提供行号的文本读取器
 */
public class LineNumberReader: TextReader
{
    private int lineNo = 0;
    private TextReader textReader = null;

    public LineNumberReader(TextReader reader)
    {
        lineNo = 0;
        textReader = reader;
    }

    public int GetLineNumber()
    {
        return lineNo;
    }

    public override string ReadLine()
    {
        if( textReader != null){
            var line = textReader.ReadLine();
            lineNo++;
            return line;
        }
        else{
            throw new Exception("No text reader provided.");
        }
    }
}