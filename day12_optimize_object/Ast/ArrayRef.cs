using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 表示抽象语法树中的数组
 * 在抽象语法树中，数组是 [] 部分的表示，重要的是其中的下标
 */
namespace week2.Ast
{
    public class ArrayRef: Postfix
    {
        public ArrayRef(IList<ASTree> list): base(list) { }
        public ASTree Index { get { return Child(0); } }
        public override string ToString()
        {
            return $"[ {Index} ]";
        }
    }
}
