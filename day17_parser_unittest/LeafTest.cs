using System;
using System.Collections.Generic;
using Xunit;
using week2.element.token;

namespace day17_parser_unittest
{
    public class LeafTest
    {
        [Fact]
        public void Leaf_Test_Parse()
        {
            string[] existTokens = new string[] { "x", "y" };
            week2.element.Leaf skip = new week2.element.Leaf(existTokens);

            var idTokenInstance = new week2.IdToken(1, "x");
            var lexer = new MockLexer(idTokenInstance);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            skip.Parse(lexer, target);
            Assert.True(target.Count == 1);
            Assert.True(target[0] is week2.ASTLeaf);
        }
    }
}