using System;

namespace week2
{
    public interface IOptimizeEnvironment
    {
        void Add(string name, object value);
        object Get(string name);
        Symbols Symbols { get; }
        void Add(int nest, int index, object value);
        object Get(int nest, int index);
        void PutNew(string name, object value);
        IOptimizeEnvironment Where(string name);
    }
}