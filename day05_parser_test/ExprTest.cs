using System;
using System.Collections.Generic;
using Xunit;
using week2;

namespace day05_parser_test
{
    public class ExprTest
    {
        [Fact]
        public void ExprTest_Test_Parse()
        {
            HashSet<string> reserved = new HashSet<string>();
            reserved.Add(";");
            reserved.Add("}");
            reserved.Add(Token.EOL);

            Operators operators = new Operators();
            operators.Add("=", 1, Operators.RIGHT);
            operators.Add("==", 2, Operators.LEFT);
            operators.Add(">", 2, Operators.LEFT);
            operators.Add("<", 2, Operators.LEFT);
            operators.Add("+", 3, Operators.LEFT);
            operators.Add("-", 3, Operators.LEFT);
            operators.Add("*", 4, Operators.LEFT);
            operators.Add("/", 4, Operators.LEFT);
            operators.Add("%", 4, Operators.LEFT);

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
            // 表达式
            Parser expr = expr0
                            .Expression(typeof(BinaryExpress), factor, operators);

            var num1 = new week2.NumToken(1, 999);
            var pre = new week2.IdToken(1, "-");
            var num2 = new week2.NumToken(1, 111);
            var tokens = new week2.Token[] { num1, pre, num2 };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            week2.ASTree result = expr.Parse( lexer);

            Assert.True( result.Count == 3 );
            Assert.True( result is BinaryExpress );
        }

        [Fact]
         public void ExprTest_Test_Parse_Less()
        {
            HashSet<string> reserved = new HashSet<string>();
            reserved.Add(";");
            reserved.Add("}");
            reserved.Add(Token.EOL);

            Operators operators = new Operators();
            operators.Add("=", 1, Operators.RIGHT);
            operators.Add("==", 2, Operators.LEFT);
            operators.Add(">", 2, Operators.LEFT);
            operators.Add("<", 2, Operators.LEFT);
            operators.Add("+", 3, Operators.LEFT);
            operators.Add("-", 3, Operators.LEFT);
            operators.Add("*", 4, Operators.LEFT);
            operators.Add("/", 4, Operators.LEFT);
            operators.Add("%", 4, Operators.LEFT);

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
            // 表达式
            Parser expr = expr0
                            .Expression(typeof(BinaryExpress), factor, operators);

            var num1 = new week2.NumToken(1, 999);
            var pre = new week2.IdToken(1, "<");
            var num2 = new week2.NumToken(1, 111);
            var tokens = new week2.Token[] { num1, pre, num2 };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            week2.ASTree result = expr.Parse( lexer);

            Console.WriteLine(".....................");
            Console.WriteLine( result);

            Assert.True( result.Count == 3 );
            Assert.True( result is BinaryExpress );
        }
    }
}