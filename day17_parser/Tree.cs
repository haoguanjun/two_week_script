

namespace Parser
{
    public class Tree : Element
    {
        protected Parser _parser;
        public Tree(Parser parser)
        {
            _parser = parser1;
        } 

        public void Parse(Lexer lexer, IList<ASTree> res)
        {
            res.Add( Parser.Parse(lexer) );
        }

        public bool Match(Lexer lexer)
        {
            return Parser.match(lexer);
        }
    }
}