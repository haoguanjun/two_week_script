using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2.Ast
{
    public class ClassStmnt: ASTList
    {
        public string Name
        {
            get
            {
                ASTLeaf leaf = Child(0) as ASTLeaf;
                return leaf.Token().Text;
            }
        }
        public string BaseClassName
        {
            get
            {
                if( Count < 3 )
                {
                    return null;
                }
                else
                {
                    ASTLeaf leaf = Child(1) as ASTLeaf;
                    return leaf.Token().Text;
                }
            }
        }
        public ClassBody Body
        {
            get
            {
                ClassBody body = Child(Count - 1) as ClassBody;
                return body;
            }
        }

        public ClassStmnt(IList<ASTree> list): base(list) { }

        public override string ToString()
        {
            return $"(class {Name} base class: {BaseClassName} {Body} )";
        }
    }
}
