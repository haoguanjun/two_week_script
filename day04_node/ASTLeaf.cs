using System.Collections;
using System.Collections.Generic;

namespace week2
{
    public class ASTLeaf: ASTree
    {
        // using a empty ArrayList to fullfile the requirement
        private static IList<ASTree> _empty = new List<ASTree>(0);

        // a leaf must has a token
        protected Token _token;
        
        public ASTLeaf(Token token)
        {
            _token = token;
        }

        // ovverride ASTree
        public override ASTree Child(int index)
        {
            throw new System.IndexOutOfRangeException();
        }

        public override int Count => 0;

        public override IEnumerator<ASTree> Children()
        {
            return _empty.GetEnumerator();
        }
        public override string Location()
        {
            return $"at line {_token.LineNumber}";
        }

        public Token Token()
        {
            return _token;
        }
        
        public override string ToString()
        {
            return _token.Text;
        }
    }
}