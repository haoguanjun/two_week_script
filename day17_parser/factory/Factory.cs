using System;
using System.Collections.Generic;
using week2;

namespace week2.factory
{
    public abstract class Factory
    {
        public static readonly string factoryName = "create";

        // 由派生类实现
        public abstract ASTree Make0(object arg);
        
        // 主要功能方法，针对待处理类型，返回专用的语法处理对象
        // 内部调用 Make0()
        public ASTree Make(object arg)
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

        // 获取针对特定类型
        //     type        抽象语法树节点类型
        //     tokenType   待处理的 Token 类型
        // 使用方式：
        //     type = typeof(ASTLeaf);
        //     _factory = Factory.Get( type, Token.GetType() );
        public static Factory Get( Type type, Type argType)
        {
            if( type == null)
                return null;

            // 尝试查看 type 是否包含 create 方法
            // 如果提供该方法，则通过该方法处理
            // 否则，尝试直接创建实例方式处理
            try{
                // 获取指定类型的 create 方法定义，调用该方法来得到 ASTree 对象实例
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