using System;
using System.Collections.Generic;

namespace week2.element
{
    public class Expr: Element
    {
        protected Factory _factory;
        protected Operators _ops;
        protected Parser  _factor;

        protected Expr(Type type, Parser exp, Operators map)
        {
            _factory = Factory.GetForASTList( type );
            _ops = map;
            _factor = exp;
        }

        public void Parse( Lexer lexer, IList<ASTree> res)
        {
            ASTree right = _factory.Parse(lexer);
            Precedence precedence;
            while( (precedence = nextOperator(lexer)) != null )
            {
                right = DoShift( lexer, right, precedence);
            }

            res.Add( right);
        }

        private ASTree DoShift(Lexer lexer, ASTree left, int prec)
        {
            List<ASTree> list = new List<ASTree>();
            list.Add(left);
            list.Add( new ASTLeaf(lexer.Read() ));
            ASTree right = _factory.Parse( lexer);

            Precedence next;
            while( (next = nextOperator(lexer)) != null
                && RightIsExpr( prec, next) )
            {
                right = DoShift( lexer, right, next.Value);
            }

            list.Add( right);
            return _factory.Make( list);
        }

        private Precedence NextOperator(Lexer lexer)
        {
            Token token = lexer.Peek(0);
            if( token.IsIdentifier())
            {
                return _ops.Get(token.Text);
            }
            else
            {
                return null;
            }
        }

        private static bool RightIsExpr(int prec, Precedence nextPrec)
        {
            if( nextPrec.LeftAssoc)
            {
                return prec < nextPrec.Value;
            }
            else
            {
                return prec <= nextPrec.Value;
            }
        }

        protected bool Match(Lexer lexer)
        {
            return _factory.Match( lexer);
        }
    }
}