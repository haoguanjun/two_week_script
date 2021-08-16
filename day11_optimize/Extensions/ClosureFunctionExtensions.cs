using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public static class ClosureFunctionExtensions
    {
        public static void PreProcess(this ClosureFunction closure, Symbols symbols)
        {
            closure.Size = PreProcess(symbols, closure.Parameters, closure.Body);
        }
        public static Object Eval(this ClosureFunction closure, IOptimizeEnvironment environment)
        {
            OptFunction func = new OptFunction(closure.Parameters, closure.Body, environment, closure.Size);
            return func;

            /*
            Function func = new Function(
                String.Empty,
                closure.Parameters,
                closure.Body,
                environment);

            return func;
            */
        }

        public static int PreProcess(Symbols symbols, ParameterList parameters, BlockStmnt body)
        {
            Symbols newSymblos = new Symbols(symbols);
            parameters.PreProcess(newSymblos);
            body.PreProcess(newSymblos);

            return newSymblos.Size;
        }
    }
}
