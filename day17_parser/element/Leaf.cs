using System;
using System.Collections.Generic;

/*
 * 初始提供一个已知 token 的集合，
 * 如果被处理的 Token 是一个 ID Token，且已经在已知 Token 集合中，则直接创建一个 ASTLeaf 叶节点
 * 如果已知 Token 集合非空，且不能在已知 Token 集合中找到，则抛出 需要预先定义此 Token 的异常
 * 如果已知 Token 集合为空，则抛出解析异常
 */
namespace week2.element
{
    public class Leaf: Element
    {
        protected String[] _tokens;
        public Leaf( String[] pat)
        {
            _tokens = pat;
        }

        public override void Parse(ILexer lexer, IList<ASTree> res )
        {
            Token token = lexer.Read();
            if( token.IsIdentifier)
            {
                foreach(string tokenText in _tokens)
                {
                    if( tokenText.Equals( token.Text ))
                    {
                        Finded(res, token);
                        return;
                    }
                }
            }

            if( _tokens.Length > 0 )
            {
                throw new ParseException(_tokens[0] + " expected.", token);
            }
            else
            {
                throw new ParseException(token);
            }
        }

        public virtual void Finded(IList<ASTree> res, Token token)
        {
            res.Add( new ASTLeaf( token ));
        }

        public override bool Match(ILexer lexer)
        {
            Token token = lexer.Peek(0);
            if( token.IsIdentifier)
            {
                foreach( string tokenName in _tokens)
                {
                    if(tokenName.Equals( token.Text))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}