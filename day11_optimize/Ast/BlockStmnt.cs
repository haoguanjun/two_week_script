using System.Collections.Generic;

namespace week2
{
    public class BlockStmnt : ASTList
    {
        public BlockStmnt(IList<ASTree> list) : base(list) { }
    }
}