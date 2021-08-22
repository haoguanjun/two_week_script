using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class StoneObject
    {
        public IOptimizeEnvironment Environment { get; private set; }
        public StoneObject(IOptimizeEnvironment env)
        {
            Environment = env;
        }

        public Object Read(string member)
        {
            return GetEnv(member)
                .Get(member);
        }

        public void Write(string member, Object value)
        {
            GetEnv(member).Add(member, value);
        }

        public IOptimizeEnvironment GetEnv(string member)
        {
            IOptimizeEnvironment e = Environment.Where(member);
            if( e != null && e == Environment)
            {
                return e;
            }
            else
            {
                throw new AccessException();
            }
        }
        public override string ToString()
        {
            return $"<object: {GetHashCode()} >";
        }
    }
}
