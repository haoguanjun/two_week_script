using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
