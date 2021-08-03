using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public static class ParameterListExtension
    {
        public static void Eval(this ParameterList parameters, IEnvironment env, int index, object value)
        {
            string name = parameters.Name(index);
            env.Add(name, value);
        }
    }
}
