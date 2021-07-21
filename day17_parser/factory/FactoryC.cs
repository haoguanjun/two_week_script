using System;
using System.Collections.Generic;

namespace week2.factory
{
    public class FactoryC: Factory
    {
        private Type _type;
        public FactoryC(Type type)
        {
            _type = type;
        }
        protected ASTree Make0(Object arg)
        {
            return System.Activator.CreateInstance(_type, arg);
        }
    }
}