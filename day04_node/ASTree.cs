using System.Collections.Generic;

namespace week2
{
    /*
     * 抽象语法树节点抽象基类
     * 表示抽象语法树中的一个节点
     * 抽象语法树可能由任意多个节点聚合形成，因此可以遍历整个语法树
     */
    public abstract class ASTree : IEnumerable<ASTree>
    {
        public abstract ASTree Child(int index);
        public abstract int Count { get; }
        public abstract IEnumerator<ASTree> Children();
        public abstract string Location();
        public IEnumerator<ASTree> GetEnumerator()
        {
            return Children();
        }

        // IEnumerable<T> inherits from IEnumerable, therefore this class
        // must implement both the generic and non-generic versions of
        // GetEnumerator. In most cases, the non-generic method can
        // simply call the generic method.
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}