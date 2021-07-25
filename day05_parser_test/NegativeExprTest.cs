using System;
using System.Collections.Generic;
using Xunit;
using week2;

namespace day05_parser_test
{
    public class NegativeExprTest
    {

        [Fact]
        public void NegativeExpr_Test_Parse_NegativeNumber()
        {
            Parser numParser = Parser.Rule().Number(typeof(NumberLiteral));
            Parser parser = Parser.Rule( typeof(NegativeExpr))
                .Sep("-")
                .Ast(numParser);

            var pre = new week2.IdToken(1, "-");
            var num2 = new week2.NumToken(1, 111);
            var tokens = new week2.Token[] { pre, num2 };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            week2.ASTree result = parser.Parse( lexer);

            Assert.True( result.Count == 1 );
            Assert.True( result is NegativeExpr );
        }
    }
}