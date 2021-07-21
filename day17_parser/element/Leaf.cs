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

        public void Parse(Lexer lexer, IList<ASTree> res )
        {
            Token token = lexer.Read();
            if( token.IsIdentifier())
            {
                foreach(string tokens in _tokens)
                {
                    if( token.equals( token.Text ))
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
            res.Add( new ASTree( token ));
        }

        public bool Match(Lexer lexer)
        {
            Token token = lexer.Peek();
            if( token.IsIdentifier())
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