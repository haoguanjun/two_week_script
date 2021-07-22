using System;
using System.Collections.Generic;
using week2;
using week2.factory;

namespace week2.element
{
    public class Expr: Element
    {
        protected Factory _factory;
        protected Operators _ops;
        protected Parser  _factor;

        public Expr(Type type, Parser exp, Operators map)
        {
            _factory = Factory.GetForASTList( type );
            _ops = map;
            _factor = exp;
        }

        public override void Parse( ILexer lexer, IList<ASTree> res)
        {
            ASTree right = _factor.Parse(lexer);
            Precedence precedence;
            while( (precedence = NextOperator(lexer)) != null )
            {
                right = DoShift( lexer, right, precedence.Value);
            }

            res.Add( right);
        }

        private ASTree DoShift(ILexer lexer, ASTree left, int prec)
        {
            List<ASTree> list = new List<ASTree>();
            list.Add(left);
            list.Add( new ASTLeaf(lexer.Read() ));
            ASTree right = _factor.Parse( lexer);

            Precedence next;
            while( (next = NextOperator(lexer)) != null
                && RightIsExpr( prec, next) )
            {
                right = DoShift( lexer, right, next.Value);
            }

            list.Add( right);
            return _factory.Make( list);
        }

        private Precedence NextOperator(ILexer lexer)
        {
            Token token = lexer.Peek(0);
            if( token.IsIdentifier)
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

        public override bool Match(ILexer lexer)
        {
            return _factor.Match( lexer);
        }
    }
}