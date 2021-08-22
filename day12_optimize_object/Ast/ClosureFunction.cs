using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    /*
     * 与普通通过 def 定义的函数类似
     */
    public class ClosureFunction : ASTList
    {
        public int Size { get; set; }
        public ClosureFunction(IList<ASTree> list) : base(list) { }
        public ParameterList Parameters { get { return Child(0) as ParameterList; } }
        public BlockStmnt Body { get { return Child(1) as BlockStmnt; } }

        public override string ToString()
        {
            return $"Closure function: parameters: {Parameters}, body: {Body}";
        }
    }
}