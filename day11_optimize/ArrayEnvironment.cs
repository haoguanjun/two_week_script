using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2 {
    /*
     * 基于数组的执行环境
     */
    public class ArrayEnvironment : IEnvironment {
        // 用来保存局部变量的数组
        private Object[] values;
        // 外层作用域
        public IEnvironment Outer { get; private set; }
        public virtual Symbols Symbols { get { throw new StoneException ($"no symbols"); } }

        // 在基于数组的执行环境中，不再使用变量名称访问，而是基于变量的当前执行环境和变量在执行环境中的下标访问
        public Object Get (int nest, int index) {
            if (nest == 0) {
                return values[index];
            } else if (Outer == null) {
                return null;
            } else {
                return Outer.Get (nest - 1, index);
            }
        }

        // 添加和更新局部变量
        public virtual void Add (int nest, int index, Object value) {
            if (nest == 0) {
                values[index] = value;
            } else if (Outer == null) {
                throw new StoneException ($"no outer environment.");
            } else {
                Outer.Add (nest - 1, index, value);
            }
        }

        // 基于数组的执行环境不再使用变量名称来访问
        public virtual object Get (string name) {
            Error (name);
            return null;
        }
        // 基于数组的执行环境不再使用变量名称来更新变量值
        public virtual void Add (string name, object value) {
            Error (name);
        }

        // 基于数组的执行环境下，每个变量预先已经确定了自己的作用域，不再需要运行时确定
        public virtual IEnvironment Where (string name) {
            Error (name);
            return null;
        }

        private void Error (string name) {
            throw new StoneException ($"cannot access by name: {name}.");
        }

        // 构造函数
        public ArrayEnv (int size, IEnvironment outer) {
            Outer = outer;
            values = new Object[size];
        }
    }
}