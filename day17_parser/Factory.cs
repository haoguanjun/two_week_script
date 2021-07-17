using System;
using System.Collections.Generic;

namespace Parser
{
    public abstract class Factory
    {
        public static readonly string factoryName = "create";

        // 由派生类实现
        protected abstract ASTree Make0(object arg) { }
        
        // 内部调用 Make0()
        protected ASTree Make(object arg)
        {
            try
            {
                return Make0(arg);
            }
            catch( IllegalArgumentException el )
            {
                throw el;
            }
            catch( Exception exception )
            {
                throw new RuntimeException( exception );
            }
        }

        public static Factory GetForASTList( Type type )
        {
            Factory f = Get( type,  typeof( IList<ASTree>) );
            if( f == null)
            {
                f = new FactoryA();
            }
            return f;
        }

        public static Factory Get( Type type, Type argType)
        {
            if( type == null)
                return null;

            try{
                System.Reflection.MethodInfo method
                    =  type.GetMethod( factoryName, new Type[]{ argType });
                var factory = new FactoryB( method);
                return factory;
            }
            catch(Exception exception) {
                throw exception;
            }

            try {
                var factory = new FactoryC(type);
                return factory;
            }
            catch(Exception exception)
            {
                throw new RuntimeException(exception);
            }
        }
    }
}