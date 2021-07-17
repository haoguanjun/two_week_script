using System;
using System.Collections.Generic;

namespace Parser
{
    internal static class AToken: Element
    {
        protected Factory _factory;
        protected AToken(Type type)
        {
            if( type == null)
            {
                type = typeof(ASTLeaf);
            }

            _factory = Factory.Get( type, Token.GetType() );
        }

        protected void Parse(Lexer lexer, IList<ASTree> res)
        {
            Token t = lexer.Read();
            if( Test(t))
            {
                ASTree leaf = _factory.Make(t);
                res.Add(leaf);
            }
            else
            {
                throw new ParseException( t );
            }
        }

        protected bool Match(Lexer lexer)
        {
            Test( lexer.Peek(0) );
        }

        protected abstract bool Test(Token token);
    }
}