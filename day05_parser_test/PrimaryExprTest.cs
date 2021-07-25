using System;
using System.Collections.Generic;
using Xunit;
using week2;

namespace day05_parser_test
{
    public class PrimaryExprTest
    {
        [Fact]
        public void Primary_Test_Parse_Number()
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

            var num2 = new week2.NumToken(1, 111);
            var tokens = new week2.Token[] {  num2 };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            week2.ASTree result = primary.Parse( lexer);

            Assert.True( result.Count == 0 );
            Assert.True( result is NumberLiteral );
        }

        [Fact]
        public void Primary_Test_Parse_String()
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

            var str = new week2.StrToken(1, "Hello");
            var tokens = new week2.Token[] { str };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            week2.ASTree result = primary.Parse( lexer);

            Assert.True( result.Count == 0 );
            Assert.True( result is week2.StringLiteral );
        }
        [Fact]
        public void Primary_Test_Parse_PlusSign()
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

            var str = new week2.IdToken(1, "<");
            var tokens = new week2.Token[] { str };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            week2.ASTree result = primary.Parse( lexer);

            Assert.True( result.Count == 0 );
            Assert.True( result is week2.Name );
        }

        [Fact]
        public void Primary_Test_Parse_Brackets()
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

            var left = new week2.IdToken(1, "(");
            // var num1 = new week2.NumToken(1, 111);
            var right = new week2.IdToken(1, ")");
            var tokens = new week2.Token[] { left, right };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            week2.ASTree result = primary.Parse( lexer);

            Assert.True( result.Count == 0 );
            Assert.True( result is week2.ASTList );
        }
    }
}
