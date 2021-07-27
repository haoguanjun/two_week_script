

public class FunctionParser: BasicParser
{
    public void Initialize()
    {
        Parser param = Parser.Rule()
                .Identifier( reserved );
        Parser params = Parser.Rule( typeof( ParameterList))
                .Ast(param).Repeat(
                    Parser.Rule().Seg(",").Ast(param)
                );
        Parser paramList = Parser.Rule()
                    .Sep("(")
                    .Maybe( params)
                    .Sep(")");
        Parser def = Parser.Rule(typeof(DefStmnt))
                    .Sep("def")
                    .Identifier(reserved)
                    .Ast(paramList)
                    .Ast(block);
        Farser args = Parser.Rule( typeof(Arguments))
                    .Ast(expr)
                    .Repeat(
                        Parser.Rule().Sep(",").Ast(expr)
                    );
        Parser postfix = Parser.Rule()
                    .Sep("(")
                    .Maybe( args)
                    .Sep(")");
    }

    public FunctionParser() {
        reserved.Add(")");

        parmary.Repeat( postfix );
        simple.Option(args);
        Program.insertChoice( def );
    }
   
                        
}