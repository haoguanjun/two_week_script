using System;
using System.Collections.Generic;
using Xunit;
using week2.element.token;

namespace day17_parser_unittest
{
    public class ParserTest
    {
        [Fact]
        public void Parser_Test_SingleNumber()
        {
            // 希望得到一个 FactoryA 类型的工厂方法
            Type nodeType = null;
            week2.Parser parser = new week2.Parser(nodeType);

            // 添加针对数字的解析支持
            parser.Number();

            var numTokenInstance = new week2.NumToken(1, 999);
            var lexer = new MockLexer(numTokenInstance);

            // 解析
            var target = parser.Parse(lexer);

            Assert.True(target.Count == 0);
            Assert.True(target is week2.ASTLeaf);
        }

        [Fact]
        public void Parser_Test_num_plus_num()
        {
            // 希望得到一个 FactoryA 类型的工厂方法
            Type nodeType = null;
            week2.Parser parser = new week2.Parser(nodeType);

            // 添加针对数字的解析支持
            parser.Number()
                .Identifier(null)
                .Number();

            var num1 = new week2.NumToken(1, 999);
            var plus = new week2.IdToken(1, "+");
            var num2 = new week2.NumToken(1, 111);
            var tokens = new week2.Token[3] { num1, plus, num2 };
            var lexer = new MockLexer(tokens);

            // 解析
            var target = parser.Parse(lexer);

            Assert.True(target.Count == 3);
            Assert.True(target is week2.ASTList);
        }

        [Fact]
        public void Parser_Test_num_plus_num_with_rule()
        {
            // 希望得到一个 FactoryA 类型的工厂方法
            // 添加针对数字的解析支持
            week2.Parser parser = week2.Parser.Rule()
                .Number()
                .Identifier(null)
                .Number();
            
            var num1 = new week2.NumToken(1, 999);
            var plus = new week2.IdToken(1, "+");
            var num2 = new week2.NumToken(1, 111);
            var tokens = new week2.Token[3] { num1, plus, num2 };
            var lexer = new MockLexer(tokens);

            // 解析
            var target = parser.Parse(lexer);

            Assert.True(target.Count == 3);
            Assert.True(target is week2.ASTList);
        }
    }
}