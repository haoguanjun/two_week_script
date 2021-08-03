using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public static class ClosureFunctionExtensions
    {
        public static Object Eval(this ClosureFunction closure, IEnvironment environment)
        {
            Function func = new Function(
                String.Empty,
                closure.Parameters,
                closure.Body,
                environment);

            return func;
        }
    }
}
