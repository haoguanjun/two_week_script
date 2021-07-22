using System;
using System.Collections.Generic;

/*
 * 通过方法对象来抽象语法树节点
 */
namespace week2.factory
{
    public class FactoryB: Factory
    {
        private System.Reflection.MethodInfo _method = null;
        public FactoryB( System.Reflection.MethodInfo method)
        {
            _method = method;
        }
        public override ASTree Make0(Object arg)
        {
            object[] args = new object[] { arg };
            ASTree result = _method.Invoke(null, args) as ASTree;
            return result;
        }
    }
}