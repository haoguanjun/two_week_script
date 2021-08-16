using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 保存执行环境中所涉及的符号，即变量名称
 * 内部为字典，保存有变量名称与其在执行环境中下标的映射
 */
namespace week2 {
    public class Symbols {
        public Symbols Outer { get; private set; }
        public IDictionary<string, int> Table { get; private set; }
        public int Size { get { return Table.Count; } }
        public Symbols () {
            Init (null);
        }
        public Symbols (Symbols outer) {
            Init (outer);
        }

        private void Init (Symbols outer) {
            Outer = outer;
            this.Table = new Dictionary<string, int> ();
        }

        // 将另一套符号添加到当前符号集中
        public void Append (Symbols s) {
            foreach (var pair in s.Table) {
                Table.Append (pair);
            }
        }

        // 使用变量名称找到对应的下标
        public int? Find (string key) {
            if( Table.ContainsKey(key))
            {
                return Table[key];
            }
            else
            {
                return null;
            }
        }

        // 根据变量名称，找到变量所对应保存位置
        // 从当前执行环境开始找
        public Location Get (string key) {
            return Get(key, 0);
        }

        // 根据变量名称，找到变量所对应的保存位置
        // 起始层级预先指定
        public Location Get(string key, int nest) {

            // 首先看当前执行环境中是否存在此变量
            if (Table.ContainsKey (key)) {
                int index = Table[key];
                return new Location (nest, index);
            } else {
                if (Outer == null) {
                    return null;
                } else {
                    return Outer.Get (key, nest + 1);
                }
            }
        }

        // 保存新的变量名称
        // 如果已经存在，返回变量所对应的下标
        // 否则添加
        public int PutNew (string key) {
            int? i = Find (key);
            if (i.HasValue) {
                return i.Value;
            } else {
                return Add (key);
            }
        }

        // 添加新的符号
        public Location Put (string key) {
            Location loc = Get (key, 0);
            if (loc == null) {
                return new Location (0, Add (key));
            } else {
                return loc;
            }
        }

        // 在当前执行环境中添加新的符号，返回符号对应的下标
        public int Add (string key) {
            int count = Size;
            Table[key] = count;
            return count;
        }

    }

    public class Location {
        // 嵌套的层数，最内层为 0, 向外依此增加 1
        public int Nest { get; private set; }

        // 变量在作用域所处的下标
        public int Index { get; private set; }
        public Location (int nest, int index) {
            Nest = nest;
            Index = index;
        }
    }
}