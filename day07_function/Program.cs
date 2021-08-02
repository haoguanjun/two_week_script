using System;
using System.IO;
using week2;

namespace week2
{
    public class FunctionLexerRunner
    {
        public static void Main(String[] args)
        {
            ClosureRunner closureRunner = new ClosureRunner();
            closureRunner.Run();
            
            
            FunctionRunner functionRunner = new FunctionRunner();
            functionRunner.Run();
            
        }

    }
}