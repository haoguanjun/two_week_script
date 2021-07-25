using System;
using System.Collections.Generic;
using Xunit;
using week2;

namespace day05_parser_test
{
    public class FactorTest
    {
        [Fact]
        public void Factor_Test_Parse_Ast_NegativeNumber()
        {
            HashSet<string> reserved = new HashSet<string>();
            reserved.Add(";");
            reserved.Add("}");
            reserved.Add(Token.EOL);

            Parser primary = Parser.Rule()
                        .Number(typeof(NumberLiteral));

            Parser factor = Parser.Rule( typeof(NegativeExpr)).Sep("-").Ast(primary);

            var pre = new week2.IdToken(1, "-");
            var num2 = new week2.NumToken(1, 111);
            var tokens = new week2.Token[] { pre, num2 };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            week2.ASTree result = factor.Parse( lexer);

            Assert.True( result.Count == 1 );
            Assert.True( result is week2.NegativeExpr );
        }

        [Fact]
        public void Factor_Test_Parse_NegativeNumber()
        {
            HashSet<string> reserved = new HashSet<string>();
            reserved.Add(";");
            reserved.Add("}");
            reserved.Add(Token.EOL);

            Parser expr0 = Parser.Rule();
            Parser primary = Parser.Rule(typeof(PrimaryExpr))
                .Or(Parser.Rule()
                        .Sep("(")
                        .Ast(expr0)
                        .Sep(")"),
                    Parser.Rule()
                        .Number(typeof(NumberLiteral)),
                    Parser.Rule()
                        .Identifier(typeof(Name), reserved),
                    Parser.Rule()
                        .String(typeof(StringLiteral))
                );

            Parser factor = Parser.Rule()
                        .Or(
                            Parser.Rule( typeof(NegativeExpr)).Sep("-").Ast(primary),
                            primary
                        );

            var pre = new week2.IdToken(1, "-");
            var num2 = new week2.NumToken(1, 111);
            var tokens = new week2.Token[] { pre, num2 };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            week2.ASTree result = factor.Parse( lexer);

            Assert.True( result.Count == 1 );
            Assert.True( result is NegativeExpr );
        }

        [Fact]
        public void Factor_Test_Parse_Number()
        {
            HashSet<string> reserved = new HashSet<string>();
            reserved.Add(";");
            reserved.Add("}");
            reserved.Add(Token.EOL);

            Parser expr0 = Parser.Rule();
            Parser primary = Parser.Rule(typeof(PrimaryExpr))
                .Or(Parser.Rule()
                        .Sep("(")
                        .Ast(expr0)
                        .Sep(")"),
                    Parser.Rule()
                        .Number(typeof(NumberLiteral)),
                    Parser.Rule()
                        .Identifier(typeof(Name), reserved),
                    Parser.Rule()
                        .String(typeof(StringLiteral))
                );

            Parser factor = Parser.Rule()
                        .Or(
                            Parser.Rule( typeof(NegativeExpr)).Sep("-").Ast(primary),
                            primary
                        );

            // var pre = new week2.IdToken(1, "-");
            var num2 = new week2.NumToken(1, 111);
            var tokens = new week2.Token[] {  num2 };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            week2.ASTree result = primary.Parse( lexer);

            Assert.True( result.Count == 0 );
            Assert.True( result is NumberLiteral );
        }
    }
}