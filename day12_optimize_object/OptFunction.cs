using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class OptFunction : Function
    {
        public int Size { get; set; }
        public OptFunction(ParameterList parameters, BlockStmnt body, IOptimizeEnvironment env, int memorySize) : base(string.Empty, parameters, body, env)
        {
            Size = memorySize;
        }

        // 创建基于数据的执行环境
        public override IOptimizeEnvironment MakeEnv()
        {
            return new ArrayEnvironment(Size, Environment);
        }
    }
}