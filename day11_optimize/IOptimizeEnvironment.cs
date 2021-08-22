using System;

namespace week2
{
    /*
     * 既需要支持基于名称的变量访问
     * 又需要支持基于数组下标的变量访问
     */
    public interface IOptimizeEnvironment
    {
        // 基于名称的变量访问
        void Add(string name, object value);
        object Get(string name);
        Symbols Symbols { get; }

        // 基于下标的变量访问
        void Add(int nest, int index, object value);
        object Get(int nest, int index);
        void PutNew(string name, object value);
        IOptimizeEnvironment Where(string name);
    }
}