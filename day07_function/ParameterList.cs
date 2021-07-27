

namespace week2
{
    public class ParameterList: ASTList
    {
        public ParameterList(IList<ASTree> list): base(list) { }

        public string Name(int index)
        {
            ASTLeaf leaf = Child( index) as ASTLeaf;
            Token token = leaf.Token();
            return  token.Text;
        }

        public int Size()
        {
            return numChildren;
        }
    }
}