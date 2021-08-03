using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class NativeFunction
    {
        public string MethodName { private set; get; }
        public MethodInfo Method { private set; get; }
        public int ParametersCount { private set; get; }
        public NativeFunction(string name, MethodInfo method)
        {
            MethodName = name;
            Method = method;
            ParametersCount = method.GetParameters().Length;
        }

        public Object Invoke(Object[] args)
        {
            return Method.Invoke(null, args);
        }
        public override string ToString()
        {
            return $"<native method: {MethodName}, {GetHashCode()}";
        }
    }
}
