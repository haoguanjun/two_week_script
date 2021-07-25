using System;
using System.Collections.Generic;
using Xunit;
using week2;
using week2.element;
using week2.element.token;

namespace day17_parser_unittest
{
    public class WhileTest
    {
        [Fact]
        public void While_Test_Parse()
        {
            // build expression
            Type tree = null;
            Parser parser = Parser.Rule().Number();
            Operators map = new Operators();
            map.Add("<", 2, Operators.LEFT);

            // Expr expr = new Expr(tree, parser, map);
            Parser expr = Parser.Rule()
                .Expression(parser, map);

            string[] sepereateTokens = new string[] { "while", "{", ";", "if" };
            week2.element.Skip skip = new week2.element.Skip(sepereateTokens);

            var p = Parser.Rule()
                .Sep("while")
                .Ast( expr )
                .Sep("{");

            var tWhile = new week2.IdToken(1, "while");
            var num1 = new week2.NumToken(1, 999);
            var plus = new week2.IdToken(1, "<");
            var num2 = new week2.NumToken(1, 111);
            var x = new week2.IdToken(1, "{");
            var tokens = new week2.Token[] { tWhile, num1, plus, num2, x };
            var lexer = new MockLexer(tokens);

            var result = p.Parse(lexer);

            Console.WriteLine( result );

            Assert.True(result.Count == 3);
        }
    }
}