using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week2.Ast;

namespace week2
{
    public class ClassInfo
    {
        public ClassStmnt Definition
        {
            get; private set;
        }
        public IOptimizeEnvironment Environment
        {
            get; private set;
        }
        public ClassInfo BaseClass
        {
            get; private set;
        }
        public string Name
        {
            get { return Definition.Name; }
        }
        public ClassBody Body
        {
            get { return Definition.Body; }
        }

        public ClassInfo(ClassStmnt stmnt, IOptimizeEnvironment env)
        {
            Definition = stmnt;
            Environment = env;
            Object obj = env.Get(stmnt.BaseClassName);
            if (obj == null)
            {
                BaseClass = null;
            }
            else if (obj is ClassInfo)
            {
                BaseClass = obj as ClassInfo;
            }
            else
            {
                throw new StoneException($"unknown base class: {stmnt.BaseClassName}");
            }
        }

        public override string ToString()
        {
            return $"<class {Name}>";
        }
    }
}