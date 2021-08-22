using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2.Ast
{
    public class Dot: Postfix
    {
        public string Name
        {
            get
            {
                ASTLeaf leaf = Child(0) as ASTLeaf;
                return leaf.Token().Text;
            }
        }
        public Dot(IList<ASTree> list): base(list) { }
        public override string ToString()
        {
            return $".{Name}";
        }
    }
}
