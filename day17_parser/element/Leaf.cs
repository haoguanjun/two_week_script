using System;
using System.Collections.Generic;

namespace week2.element
{
    public class Leaf: Element
    {
        protected String[] _tokens;
        public Leaf( String[] pat)
        {
            _tokens = pat;
        }

        public override void Parse(ILexer lexer, IList<ASTree> res )
        {
            Token token = lexer.Read();
            if( token.IsIdentifier)
            {
                foreach(string tokenText in _tokens)
                {
                    if( tokenText.Equals( token.Text ))
                    {
                        Finded(res, token);
                        return;
                    }
                }
            }

            if( _tokens.Length > 0 )
            {
                throw new ParseException(_tokens[0] + " expected.", token);
            }
            else
            {
                throw new ParseException(token);
            }
        }

        public void Finded(IList<ASTree> res, Token token)
        {
            res.Add( new ASTLeaf( token ));
        }

        public override bool Match(ILexer lexer)
        {
            Token token = lexer.Peek(0);
            if( token.IsIdentifier)
            {
                foreach( string tokenName in _tokens)
                {
                    if(tokenName.Equals( token.Text))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}