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
        public static void PreProcess(this DefStmnt def, Symbols symbols)
        {
            def.Index = symbols.PutNew(def.Name);
            def.Size = ClosureFunctionExtensions.PreProcess(symbols, def.Parameters, def.Body);
        }

        public static object Eval(this week2.DefStmnt def, IOptimizeEnvironment env)
        {
            OptFunction fun = new OptFunction(def.Parameters, def.Body, env, def.Size);
            env.Add(0, def.Index, fun);

            return def.Name;
            /*
            Function function = new Function(
                def.Name,
                def.Parameters,
                def.Body,
                env);

            env.Add(
                def.Name,
                function);
            return def.Name;
            */
        }
    }
}
