using System;
using System.Collections.Generic;

namespace Parser
{
    public class Repeat: Element
    {
        protected Parser _parser;
        protected bool _onlyOne;
        public Repeat(Parser parser, bool once)
        {
            _parser = parser;
            _onlyOne = once;
        }

        public void Parse(Lexer lexer, IList<ASTree> res)
        {
            while(_parser.Match(lexer))
            {
                ASTree t = _parser.Parse(lexer);
                if( !(t is ASTList) || t.numChildren > 0 )
                {
                    res.Add( t );
                }

                if( _onlyOne)
                {
                    break;
                }
            }
        }

        public bool Match(Lexer lexer)
        {
            return _parser.Match(lexer);
        }
    }
}