using System.Collections.Generic;
using week2;

namespace week2.element
{
    public class Tree : Element
    {
        protected Parser _parser;
        public Tree(Parser parser)
        {
            _parser = parser;
        } 

        public override void Parse(ILexer lexer, IList<ASTree> res)
        {
            res.Add( _parser.Parse(lexer) );
        }

        public override bool Match(ILexer lexer)
        {
            return _parser.Match(lexer);
        }
    }
}