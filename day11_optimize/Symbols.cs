using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class Symbols
    {
        public Symbols Outer { get; private set; }
        public IDictionary<string, int> Table { get; private set; }
        public int Size { get { return Table.Count; } }
        public Symbols() {
            Init(null); 
        }
        public Symbols(Symbols outer)
        {
            Init(outer);
        }

        private void Init(Symbols outer)
        {
            Outer = outer;
            this.Table = new Dictionary<string, int>();
        }

        public void Append(Symbols s)
        {
            foreach(var pair in s.Table)
            {
                Table.Append(pair);
            }
        }
        public int Find(string key)
        {
            return Table[key];
        }

        public Location Get(string key)
        {
            return Get(key);
        }

        public Location Get(string key, int nest)
        {
            int index = Table[key];
            if( Table.ContainsKey(key))
            {
                return new Location(nest, index);
            }
            else
            {
                if(Outer == null)
                {
                    return null;
                }
                else
                {
                    return Outer.Get(key, nest - 1);
                }
                
            }
        }

        public int PutNew(string key)
        {
            int? i = Find(key);
            if( i == null)
            {
                return Add(key);
            }
            else
            {
                return i;
            }
        }

        public Location Put(string key)
        {
            Location loc = Get(key, 0);
            if( loc == null)
            {
                return new Location(0, Add(key));
            }
            else
            {
                return loc;
            }
        }

        public int Add(string key)
        {
            int count = Size;
            Table[key] = count;
            return count;
        }

    }

    public class Location
    {
        public int Nest { get; private set; }
        public int Index { get; private set; }
        public Location(int nest, int index)
        {
            Nest = nest;
            Index = index;
        }
    }
}
