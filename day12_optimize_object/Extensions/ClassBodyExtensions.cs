using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week2.Ast;

namespace week2
{
    public static class ClassBodyExtensions
    {
        public static Object Eval(this ClassBody body, IOptimizeEnvironment env)
        {
            foreach (ASTree node in body)
            {
                node.Eval(env);
            }
            return null;
        }
    }
}