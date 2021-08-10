using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week2;

/*
 * 对于函数定义，就是将定义保存到执行环境中
 */
namespace week2
{
    public static class DefStmntExtentions
    {
        public static object Eval(this week2.DefStmnt def, IOptimizeEnvironment env)
        {
            Function function = new Function(
                def.Name,
                def.Parameters,
                def.Body,
                env);

            env.Add(
                def.Name,
                function);
            return def.Name;
        }
    }
}
