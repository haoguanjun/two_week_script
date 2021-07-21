using System;
using System.Collections.Generic;
using week2;
using week2.element;
using week2.factory;
/*
 * 处理基本的 3 种 Token
 */
namespace week2.element.token
{
    public class AToken: Element
    {
        protected Factory _factory;
        public AToken(Type type)
        {
            if( type == null)
            {
                type = typeof(ASTLeaf);
            }

            _factory = Factory.Get( type, Token.GetType() );
        }

        protected void Parse(Lexer lexer, IList<ASTree> res)
        {
            Token t = lexer.Read();

            // 调用实现类的 Test 方法
            if( Test(t))
            {
                ASTree leaf = _factory.Make(t);
                res.Add(leaf);
            }
            else
            {
                throw new ParseException( t );
            }
        }

        protected bool Match(Lexer lexer)
        {
            Test( lexer.Peek(0) );
        }

        protected abstract bool Test(Token token);
    }
}