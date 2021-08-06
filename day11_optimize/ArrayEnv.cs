using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class ArrayEnv: IEnvironment
    {
        private Object[] values;
        public IEnvironment Outer { get; private set; }
        public Symbols Symbols()
        {
            throw new StoneException($"no symbols");
        }

        public Object Get(int nest, int index)
        {
            if(nest ==0)
            {
                return values[index];
            }
            else if( Outer == null)
            {
                return null;
            }
            else
            {
                return Outer.Get(nest - 1, index);
            }
        }

        public void Add(int nest, int index, Object value)
        {
            if( nest == 0)
            {
                values[index] = value;
            }
            else if( Outer == null)
            {
                throw new StoneException($"no outer environment.");
            }
            else
            {
                Outer.Add(nest - 1, index, value);
            }
        }
        public object Get(string name)
        {
            Error(name);
            return null;
        }
        public void Add(string name, object value)
        {
            Error(name);
        }

        public IEnvironment Where(string name)
        {
            Error(name);
            return null;
        }

        private void Error(string name)
        {
            throw new StoneException($"cannot access by name: {name}.");
        }

        public ArrayEnv(int size, IEnvironment outer)
        {
            Outer = outer;
            values = new Object[size];
        }
    }
}
