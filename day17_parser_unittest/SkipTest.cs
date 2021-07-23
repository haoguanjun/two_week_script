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
    }
}