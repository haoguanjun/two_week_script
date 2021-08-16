using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class Function
    {
        public string Name { get; private set; }
        public ParameterList Parameter { get; private set; }
        public BlockStmnt Body { get; private set; }
        protected IOptimizeEnvironment Environment { get; private set; }

        public Function(string name, ParameterList parameter, BlockStmnt body, IOptimizeEnvironment env)
        {
            Name = name;
            Parameter = parameter;
            Body = body;
            Environment = env;
        }

        // 创建函数的执行环境
        public virtual IOptimizeEnvironment MakeEnv()
        {
            IOptimizeEnvironment innerEnv = new ArrayEnvironment(10, Environment);
            return innerEnv;
        }
        public override string ToString()
        {
            return $"<def function=> name: {Name}, HashCode: {this.GetHashCode()} >";
        }
    }
}
