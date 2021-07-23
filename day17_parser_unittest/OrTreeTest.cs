using System;
using System.Collections.Generic;
using Xunit;
using week2.element.token;

namespace day17_parser_unittest
{
    public class OrTreeTest
    {
        [Fact]
        public void OrTree_Test_Parse()
        {
            week2.Parser parser1 = week2.Parser.Rule()
                .Number();
            week2.Parser parser2 = week2.Parser.Rule()
                .Identifier(null);
            week2.Parser[] parsers = new week2.Parser[] { parser1, parser2 };
            week2.element.OrTree or = new week2.element.OrTree( parsers);

            var idTokenInstance = new week2.IdToken(1, ";");
            var lexer = new MockLexer(idTokenInstance);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            or.Parse(lexer, target);

            Assert.True(target.Count == 1);
            Assert.True( target[0] is week2.ASTLeaf );
        }
    }
}