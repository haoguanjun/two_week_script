using System.Collections.Generic;

namespace week2
{
    public class BinaryExpress: ASTList
    {
        public BinaryExpress(IList<ASTree> list): base( list) {}
        public ASTree Left
        {
            // define the left at 0
            get { return _children[0]; }
        }
        public ASTree Right
        {
            get { return _children[2];}
        }

        public string Operator
        {
            get { 
                ASTLeaf leaf = _children[1] as ASTLeaf;
                return leaf.Token().Text; }
        }
    }
}