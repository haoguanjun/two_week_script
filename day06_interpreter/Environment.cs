using System;

namespace week2
{
    public interface IEnvironment
    {
        void Add(string name, object value);
        object Get(string name);
    }
}