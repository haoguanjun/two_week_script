using System;
using System.Collections.Generic;

namespace week2
{
    public class BasicEnv : IEnvironment
    {
        private System.Collections.Generic.Dictionary<string, object> _values;

        public BasicEnv()
        {
            _values = new Dictionary<string, object>();
        }

        public void Add(string name, object value)
        {
            // if the name existed, just override it.
            _values[name] = value;
        }
        public object Get(string name)
        {
            return _values[name];
        }

        public IEnvironment Where(string name)
        {
            // 这里是 Outer，即最外部的公共执行环境
            if( _values.ContainsKey( name))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}
