using System;
using System.Collections.Generic;
using week2;
using week2.element;
using week2.factory;
/*
 * 处理基本的 3 种 Token 的规则处理器基类
 */
namespace week2.element.token
{
    public class AToken : Element
    {
        protected Factory _factory;

        // 参数为生成的抽象语法树节点类型
        // null 表示使用 ASTLeaf 节点
        public AToken(Type type)
        {
            if (type == null)
            {
                type = typeof(ASTLeaf);
            }

            _factory = Factory.Get(type, typeof(Token));
        }

        public override void Parse(ILexer lexer, IList<ASTree> res)
        {
            Token t = lexer.Read();

            // 调用实现类的 Test 方法
            if (Test(t))
            {
                ASTree leaf = _factory.Make(t);
                res.Add(leaf);
            }
            else
            {
                throw new ParseException(t);
            }
        }

        public override bool Match(ILexer lexer)
        {
            return Test(lexer.Peek(0));
        }

        public virtual bool Test(Token token) { return false; }
    }
}