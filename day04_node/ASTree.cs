using System.Collections.Generic;

namespace week2
{
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