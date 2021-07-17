using System;
using System.Collections.Generic;

namespace Parser
{
    internal static class OrTree : Element
    {
        protected Parser[] _parsers;

        public OrTree(Parser[] parsers)
        {
            _parsers = parsers;
        }

        public void Parse(Lexer lexer, IList<ASTree> res)
        {
            Parser parser  = Choice(lexer);
            if( parser == null)
            {
                throw new ParserException(lexer.Peek(0));
            }
            else{
                res.Add( parser.Parse(lexer));
            }
        }

        public bool Match(Lexer lexer)
        {
            return Choice(lexer) != null;
        }

        public Parser Choice(Lexer lexer)
        {
            foreach(Parser parser in _parsers)
            {
                if( parser.Match(lexer))
                    return parser;
            }
            return null;
        }

        public void Insert(Parser parser)
        {
            Parser[] newParsers = new Parser[_parsers.Length + 1];
            newParsers[0] = parser;
            System.Array.Copy(_parsers, newParsers, 1, _parsers.Length);
            _parsers = newParsers;
        }
    }

}