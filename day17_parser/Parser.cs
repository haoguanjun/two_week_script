using System;
using System.Collections.Generic;

namespace Parser
{
    public class Parser
    {
        public static readonly string factoryName = "create";
        protected IList<Element> _elements;
        protected Factory  _factory;

        public Parser( Type type)
        {
            Reset(type);
        }

        protected Parser(Parser p)
        {
            _elements = p._elements;
            _factory = p._factory;
        }

        public ASTree Parse(Lexer lexer)
        {
            IList<ASTree> results = new List<ASTree>();
            foreach( var element in _elements)
            {   
                element.Parse(lexer, results);
            }

            return _factory.Make(results);
        }

        protected bool Match(Lexer lexer)
        {
            if( _elements.Count == 0)
            {
                return true;
            }
            else
            {
                Element first = _elements[0];
                return first.Match(lexer);
            }
        }

        public static Parser Rule()
        {
            return Rule(null);
        }

        public static Parser Rule(Type type)
        {
            return new Parser(type);
        }

        public Parser Reset()
        {
             _elements = new List<Element>();
             return this;
        }

        public Parser Reset(Type type)
        {
            _elements = new List<Element>();
            _factory = Factory.GetForASTList(type);
            return this;
        }

        public Parser Number()
        {
            return Number(null);
        }

        public Parser Number(Type type)
        {
            _elements.Add( new NumToken(type));
            return this;
        }

        public Parser Identifier(HashSet<String> reserved)
        {
            return Identifier(null, reserved);
        }

        public Parser Identifier(Type type, HashSet<String> reserved)
        {
            _elements.Add( IdToken(type, reserved));
            return this;
        }

        public Parser String()
        {
            return String(null);
        }

        public Parser String(Type type)
        {
            _elements.Add(new StringToken(type));
            return this;
        }

        public Parser Token(String pattern)
        {
            _elements.Add(new Leaf( pattern));
            return this;
        }

        public Parser Sep(String pattern)
        {
            _elements.Add(new Skip(pattern));
            return this;
        }

        public Parser Ast(Parser p)
        {
            _elements.Add( new Tree( p));
            return this;
        }

        public Parser Or(Parser p)
        {
            _elements.Add(new OrTree(p));
            return this;
        }

        public Parser Maybe(Parser p)
        {
            Parser p2 = new Parser(p);
            p2.Reset();
            _elements.Add(new OrTree( new Parser[]{ p, p2 }));
            return this;            
        }

        public Parser Option(Parser p)
        {
            _elements.Add(new Repeat(p, true));
            return this;
        }

        public Parser Repeat(Parser p)
        {
            _elements.Add(new Repeat(p, false));
            return this;
        }

        public Parser Expression(Parser subExp, Operators operators)
        {
            _elements.Add(new Expr(null, subExp, operators));
            return this;
        }

        public Parser Expression(Type type, Parser subExp, Operators operators)
        {
            _elements.Add(new Expr(type, subExp, operators));
            return this;
        }

        public Parser InsertChoice(Parser p)
        {
            Element first = _elements[0];
            if( first is OrTree)
            {
                (first as OrTree).Insert(p);
            }
            else
            {
                Parser otherwise = new Parser(this);
                Reset(null);
                Or(p, otherwise);
            }

            return this;
        }

         
    }
}