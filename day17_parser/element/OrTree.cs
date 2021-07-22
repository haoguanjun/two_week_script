using System;
using System.Collections.Generic;
using week2;

/*
 * 表示 or 结构
 */
namespace week2.element
{
    public class OrTree : Element
    {
        protected Parser[] _parsers;

        public OrTree(Parser[] parsers)
        {
            _parsers = parsers;
        }

        public override void Parse(Lexer lexer, IList<ASTree> res)
        {
            Parser parser  = Choice(lexer);
            if( parser == null)
            {
                throw new ParseException(lexer.Peek(0));
            }
            else{
                res.Add( parser.Parse(lexer));
            }
        }

        public override bool Match(Lexer lexer)
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
            for(int index = 1; index < newParsers.Length; index++)
            {
                newParsers[index] = _parsers[index-1];
            }
            _parsers = newParsers;
        }
    }

}