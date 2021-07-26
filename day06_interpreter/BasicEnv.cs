using System;
using System.Collections.Generic;

namespace week2
{
    public class BasicEnv: IEnvironment
    {
        private System.Collections.Generic.Dictionary<string, object> _values;

        public BasicEnv()
        {
            _values = new Dictionary<string, object>();
        }

        public void Add(string name, object value)
        {
            _values.Add( name, value);
        }
        public object Get(string name)
        {
            return _values[name];
        }
    }
}