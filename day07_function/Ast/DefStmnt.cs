using System;
using System.Collections.Generic;

namespace week2
{
    public class DefStmnt : ASTList
    {
        public DefStmnt(IList<ASTree> list) : base(list) { }
        public string Name
        {
            get
            {
                ASTLeaf leaf = Child(0) as ASTLeaf;
                Token token = leaf.Token();
                return token.Text;
            }
        }

        public ParameterList Parameters
        {
            get
            {
                return Child(1) as ParameterList;
            }
        }

        public BlockStmnt Body
        {
            get
            {
                BlockStmnt block = Child(2) as BlockStmnt;
                return block;
            }
        }

        public override string ToString()
        {
            return $"( def {Name}  {Parameters} {Body}";
        }
    }
}