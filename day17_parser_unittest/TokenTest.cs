using System;
using System.Collections.Generic;
using Xunit;
using week2.element.token;

namespace day17_parser_unittest
{
    public class TokenTest
    {
        [Fact]
        public void IdToken_test_Test()
        {
            Type targetType = null;                         // default: typeof( ASTLeaf);
            HashSet<string> reserved = null;                // default: new HashSet();
            var idTokenElement = new IdToken(targetType, reserved);

            var idTokenInstance = new week2.IdToken(1, "x");

            var result = idTokenElement.Test(idTokenInstance);
            Assert.True(result);
        }

        [Fact]
        public void IdToken_test_Parse()
        {
            Type targetType = null;                         // default: typeof( ASTLeaf);
            HashSet<string> reserved = null;                // default: new HashSet();
            var idTokenElement = new IdToken(targetType, reserved);
            var idTokenInstance = new week2.IdToken(1, "x");
            IList<week2.ASTree> target = new List<week2.ASTree>();

            var lexer = new MockLexer(idTokenInstance);

            idTokenElement.Parse(lexer, target);
            Assert.True(target.Count == 1);
            Assert.True(target[0] is week2.ASTLeaf);
        }

        [Fact]
        public void NumToken_test_Parse()
        {
            Type targetType = null;                         // default: typeof( ASTLeaf);
            var numTokenElement = new NumToken(targetType);
            var numTokenInstance = new week2.NumToken(1, 999);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            var lexer = new MockLexer(numTokenInstance);

            numTokenElement.Parse(lexer, target);
            Assert.True(target.Count == 1);
            Assert.True(target[0] is week2.ASTLeaf);
        }

        [Fact]
        public void StringToken_test_Parse()
        {
            Type targetType = null;                         // default: typeof( ASTLeaf);
            var stringTokenElement = new StringToken(targetType);
            var stringTokenInstance = new week2.StrToken(1, "Hello");
            IList<week2.ASTree> target = new List<week2.ASTree>();

            var lexer = new MockLexer(stringTokenInstance);

            stringTokenElement.Parse(lexer, target);
            Assert.True(target.Count == 1);
            Assert.True(target[0] is week2.ASTLeaf);
        }        
    }
}
