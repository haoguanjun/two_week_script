using System;
using System.Collections.Generic;
using week2;
using week2.element;
using week2.element.token;

/*
 * 表示重复结构，在本例中，即 while 循环结构
 */
namespace week2
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

        public override void Parse(ILexer lexer, IList<ASTree> res)
        {
            while(_parser.Match(lexer))
            {
                ASTree t = _parser.Parse(lexer);
                if( !(t is ASTList) || t.Count > 0 )
                {
                    res.Add( t );
                }

                if( _onlyOne)
                {
                    break;
                }
            }
        }

        public override bool Match(ILexer lexer)
        {
            return _parser.Match(lexer);
        }
    }
}