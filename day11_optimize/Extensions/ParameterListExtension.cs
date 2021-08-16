using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public static class ParameterListExtension
    {
        public static void PreProcess(this ParameterList parameters, Symbols symbols)
        {
            int size = parameters.Size();
            parameters.Offsets = new int[size];
            for(int index = 0; index< size; index++)
            {
                int i = symbols.PutNew(parameters.Name(index));
                parameters.Offsets[index] = i;
            }
        }
        public static void Eval(this ParameterList parameters, IOptimizeEnvironment env, int index, object value)
        {
            env.Add(0, parameters.Offsets[index], value);

            /*
            string name = parameters.Name(index);
            env.Add(name, value);
            */
        }
    }
}
