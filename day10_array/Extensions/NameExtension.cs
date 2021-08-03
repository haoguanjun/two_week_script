using System;
using week2;

namespace week2
{
    public static class NameExtension
    {
        public static object Eval(this Name token, IEnvironment env)
        {
            string name = token.NameString();
            object value = env.Get(name);
            if (value == null)
            {
                throw new StoneException($"undefined name: {name}");
            }
            else
            {
                return value;
            }
        }
    }
}
