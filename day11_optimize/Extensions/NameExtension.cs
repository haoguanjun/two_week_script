using System;
using week2;

namespace week2
{
    public static class NameExtension
    {
        public static void PrePrecess(this Name name, Symbols symbols)
        {
            Location loc = symbols.Get(name.NameString());
            if( loc == null)
            {
                throw new StoneException($"undefined name: {name.NameString()}");
            }
            else
            {
                name.Nest = loc.Nest;
                name.Index = loc.Index;
            }
        }

        public static object Eval(this Name token, IOptimizeEnvironment env)
        {
            if( token.Index == Name.UNKNOWN)
            {
                return env.Get(token.NameString());
            }
            else
            {
                return env.Get(token.Nest, token.Index);
            }
            /*
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
            */
        }

        public static void PrePreocessForAssign(this Name name, Symbols symbols)
        {
            string nameString = name.NameString();
            Location loc = symbols.Put(nameString);
            name.Nest = loc.Nest;
            name.Index = loc.Index;
        }

        public static void EvalForAssign(this Name name, IOptimizeEnvironment env, object value)
        {
            if( name.Index == Name.UNKNOWN)
            {
                env.Add(name.NameString(), value);
            }
            else
            {
                env.Add(name.Nest, name.Index, value);
            }
        }


    }
}
