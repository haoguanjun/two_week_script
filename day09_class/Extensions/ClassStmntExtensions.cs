using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week2.Ast;

namespace week2
{
    public static class ClassStmntExtensions
    {
        public static Object Eval(this ClassStmnt stmnt, IEnvironment env)
        {
            ClassInfo info = new ClassInfo(stmnt, env);
            string name = stmnt.Name;
            env.Add(name, info);
            return stmnt.Name;
        }
    }
}
