using System;
using System.Collections.Generic;

/*
 * 内嵌的执行环境
 *   提供指向外部公共执行环境的引用 Outer
 */
namespace week2
{
    public class NestedEnv : IEnvironment
    {
        private System.Collections.Generic.Dictionary<string, object> _values;
        public IEnvironment Outer { get; set; }
        public NestedEnv() { Init(null); }
        public NestedEnv(IEnvironment outer)
        {
           Init(outer);
        }

        private void Init(IEnvironment outer)
        {
            Outer = outer;
            _values = new Dictionary<string, object>();
        }

        // 为变量赋值的时候，首先检查原来是否存在此变量
        // 如果不存在，则在当前作用域创建
        // 如果存在于某个作用域，则在原来的作用域重新赋值
        public void Add(string name, object value)
        {
            IEnvironment env = Where(name);
            if (env == null || env == this)
            {
                _values[name] = value;
            }
            else
            {
                Outer.Add(name, value);
            }
        }

        // 读取变量值的时候
        // 首先检查当前作用域是否存在此变量，如果存在从当前作用域读取
        // 否则，从外层作用域读取
        public object Get(string name)
        {
            object value = _values[name];
            if (value == null && Outer != null)
            {
                return Outer.Get(name);
            }
            else
            {
                return value;
            }
        }
        public IEnvironment Where(string name)
        {
            if (_values.ContainsKey(name))
            {
                return this;
            }
            else if (Outer == null)
            {
                return null;
            }
            else
            {
                return Outer.Where(name);
            }
        }

    }
}