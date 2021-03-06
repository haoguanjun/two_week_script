using System;
using System.Collections.Generic;
using Xunit;
using week2.element.token;

namespace day17_parser_unittest
{
    public class SkipTest
    {
        [Fact]
        public void Skip_Test_Parse()
        {
            string[] sepereateTokens = new string[] { "(", ")", ";", "if" };
            week2.element.Skip skip = new week2.element.Skip(sepereateTokens);

            var idTokenInstance = new week2.IdToken(1, ";");
            var lexer = new MockLexer(idTokenInstance);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            skip.Parse(lexer, target);
            Assert.True(target.Count == 0);
        }

        [Fact]
        public void Skip_Test_Parse_Next()
        {
            string[] sepereateTokens = new string[] { "(", ")", ";", "if" };
            week2.element.Skip skip = new week2.element.Skip(sepereateTokens);
            week2.Parser parser 
                = week2.Parser.Rule().Sep( sepereateTokens).Number();

            var skip1 = new week2.IdToken(1, ";");
            var num1 = new week2.NumToken(1, 8);
            var tokens = new week2.Token[] { skip1, num1 };
            var lexer = new MockLexer(tokens);

            week2.ASTree result = parser.Parse(lexer);

            Assert.True(result.Count == 0);
            Assert.True( result is week2.ASTLeaf );
        }
    }
}