using System.Collections.Generic;

/*
 * 表示数组字面量，例如 [ 1, 2, 3 ] 形式的数组
 */
namespace week2.Ast
{
    public class ArrayLiteral: ASTList
    {
        public ArrayLiteral(IList<ASTree> list) : base(list) { }
        public int Size {  get { return Count; } }
    }
}
