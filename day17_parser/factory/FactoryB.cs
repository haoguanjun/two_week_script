using System;
using System.Collections.Generic;

namespace week2.factory
{
    internal class FactoryB: Factory
    {
        private System.Reflection.MethodInfo _method = null;
        public FactoryB( System.Reflection.MethodInfo method)
        {
            _method = method;
        }
        protected ASTree Make0(Object arg)
        {
            ASTree result = _method.Invoke(null, arg) as ASTree;
            return result;
        }
    }
}