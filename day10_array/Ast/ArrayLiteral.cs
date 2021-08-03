using System.Collections.Generic;

namespace week2.Ast
{
    public class ArrayLiteral: ASTList
    {
        public ArrayLiteral(IList<ASTree> list) : base(list) { }
        public int Size {  get { return Count; } }
    }
}
