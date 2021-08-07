using System;
using System.Collections.Generic;

/*
 * 用于全局变量的执行环境
 */
namespace week2 {
    public class ResizableArrayEnvironment : ArrayEnvironment {
        // 全局执行环境中使用的符号表
        private Symbols names;
        // 默认容量 10
        // 作为最顶级执行环境，没有外层的执行环境
        public ResizableArrayEnvironment () : base (10, null) {
            names = new Symbols ();
        }

        public override Symbols Symbols => names;

        // 读取变量值
        public override object Get (string name) {
            int? index = names.Find (name);
            if (index.HasValue) {
                return values[index];
            } else {
                if (Outer == null) {
                    return null;
                } else {
                    return Outer.Get (name);
                }
            }
        }

        // 保存变量值
        public override void Add(string name, object value)
        {
            IEnvironment env = Where(name);
            if( env == null)
            {
                env = this;
            }
            else
            {
                env.Add(name, value);
            }
        }

        // 保存新的变量值
        // 需要先将变量名称保存到符号表中
        public void PutNew(string name, object value)
        {
            int index = names.PutNew(name);
            Assign(index, value);
        }

        public override IEnvironment Where(string name)
        {
            if( names.Find(name).HasValue)
            {
                return this;
            }
            else if( Outer == null)
            {
                return null;
            }
            else
            {
                Outer.Where(name);
            }
        }

        public override void Add(int nest, int index, object value)
        {
            if( nest == 0 )
            {
                Assign(index, value);
            }
            else
            {
                base.Add(nest, index, value);
            }
        }

        private void Assign(int index, object value)
        {
            if( index >= values.Length)
            {
                // 扩展数组空间
                int newLength = values.Length * 2;
                if(index >= newLength)
                {
                    newLength = index + 1;
                }
                object[] newArray = new object[ newLength];
                Array.Copy(values, newArray, values.Length); 
                values = newArray;
            }

            values[index] = value;
        }
    }
}