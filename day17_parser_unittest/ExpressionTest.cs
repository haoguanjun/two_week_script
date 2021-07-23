using System;
using System.Collections.Generic;
using Xunit;
using week2;
using week2.element;
using week2.element.token;

namespace day17_parser_unittest
{
    public class ExprTest
    {
        [Fact]
        public void Expr_test_Parse()
        {
            Type tree = null;
            Parser parser = Parser.Rule().Number();
            Operators map = new Operators();
            map.Add("+", 2, Operators.LEFT);

            Expr expr = new Expr(tree, parser, map);

            var num1 = new week2.NumToken(1, 999);
            var plus = new week2.IdToken(1, "+");
            var num2 = new week2.NumToken(1, 111);
            var tokens = new week2.Token[3] { num1, plus, num2 };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            expr.Parse(lexer, target);

            Assert.True(target[0] is ASTList);
            Assert.True(target.Count == 1);
            Assert.True(target[0].Count == 3);
        }

        [Fact]
        public void Expr_test_Parse2()
        {
            Type tree = null;
            Parser parser = Parser.Rule().Number();
            Operators map = new Operators();
            map.Add("+", 2, Operators.LEFT);
            map.Add("*", 4, Operators.LEFT);

            Expr expr = new Expr(tree, parser, map);

            var num1 = new week2.NumToken(1, 999);
            var plus = new week2.IdToken(1, "+");
            var num2 = new week2.NumToken(1, 111);
            var minues = new week2.IdToken(1, "*");
            var num3 = new week2.NumToken(1, 2);
            var tokens = new week2.Token[5] { num1, plus, num2, minues, num3 };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            expr.Parse(lexer, target);

            Assert.True(target[0] is ASTList);
            Assert.True(target.Count == 1);
            Assert.True(target[0].Count == 3);
            Assert.True(target[0].Child(2) is ASTList);
            Assert.True(target[0].Child(2).Count == 3);
        }
    }
}