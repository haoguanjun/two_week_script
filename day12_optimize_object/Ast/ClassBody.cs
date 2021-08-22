using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2.Ast
{
    public class ClassBody: ASTList
    {
        public ClassBody(IList<ASTree> c) : base(c) { }
    }
}
