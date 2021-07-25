using System;
using System.Collections.Generic;
using week2.factory;
using week2.element;
using week2.element.token;

namespace week2
{
    public class Parser
    {
        public static readonly string factoryName = "create";
        public IList<Element> _elements;
        protected Factory  _factory;

        // 返回解析特定类型的解析器
        public Parser( Type type)
        {
            Reset(type);
        }

        protected Parser(Parser p)
        {
            _elements = p._elements;
            _factory = p._factory;
        }

        public ASTree Parse(ILexer lexer)
        {
            IList<ASTree> results = new List<ASTree>();

            foreach( var element in _elements)
            {   
                element.Parse(lexer, results);
            }

            return _factory.Make(results);
        }

        public bool Match(ILexer lexer)
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

        // 构建一个空白的解析器
        public static Parser Rule()
        {
            return Rule(null);
        }

        public static Parser Rule(Type type)
        {
            return new Parser(type);
        }

        // 当使用 Rule() 来构建空白规则时
        public Parser Reset()
        {
             _elements = new List<Element>();
             return this;
        }

        // 当提供 Type 来构建规则时
        public Parser Reset(Type type)
        {
            _elements = new List<Element>();
            _factory = Factory.GetForASTList(type);
            return this;
        }

        // 增加 Number 类型处理
        public Parser Number()
        {
            // null 默认为生成 leaf 节点
            return Number(null);
        }

        public Parser Number(Type type)
        {
            _elements.Add( new week2.element.token.NumToken(type));
            return this;
        }

        // 增加 Id 处理
        public Parser Identifier(HashSet<String> reserved)
        {
            // null 默认生成 leaf 节点
            return Identifier(null, reserved);
        }

        public Parser Identifier(Type type, HashSet<String> reserved)
        {
            _elements.Add( new week2.element.token.IdToken(type, reserved));
            return this;
        }

        // 增加 String 类型处理，处理结果为 ASTLeaf
        public Parser String()
        {
            // null 默认生成 leaf 节点
            return String(null);
        }

        public Parser String(Type type)
        {
            _elements.Add(new StringToken(type));
            return this;
        }

        // 增加普通标记处理，处理结果为 叶
        public Parser Token(params string[] pattern )
        {
            _elements.Add(new Leaf( pattern));
            return this;
        }

        public Parser Sep(params String[] pattern)
        {
            _elements.Add(new Skip(pattern));
            return this;
        }

        public Parser Ast(Parser p)
        {
            _elements.Add( new Tree( p));
            return this;
        }

        public Parser Or(params Parser[] p)
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