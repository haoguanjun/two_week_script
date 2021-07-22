using System;
using System.Collections.Generic;

/*
 * 构造提供的类型对象实例
 */
namespace week2.factory
{
    public class FactoryC: Factory
    {
        private Type _type;
        public FactoryC(Type type)
        {
            _type = type;
        }
        public override ASTree Make0(Object arg)
        {
            return System.Activator.CreateInstance(_type, arg) as ASTree;
        }
    }
}