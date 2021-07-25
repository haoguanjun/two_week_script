using System;
using System.Collections.Generic;
using Xunit;
using week2;

namespace day05_parser_test
{
    public class WhileTest
    {
        [Fact]
        public void While_Test_Parse_Ast_NegativeNumber()
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

            // 空规则
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

            // Parser factor = Parser.Rule( typeof(NegativeExpr)).Sep("-").Ast(primary);
            Parser factor = Parser.Rule()
                            .Or(Parser.Rule(typeof(NegativeExpr))
                                .Sep("-")
                                .Ast(primary),
                                primary
                            );


            // 表达式
            Parser expr = expr0
                            .Expression(typeof(BinaryExpress), factor, operators);

            Parser statement0 = Parser.Rule();

            Parser whileParser = Parser.Rule(typeof(WhileStmnt))
                                        .Sep("while")
                                        .Ast(expr);
                                        // .Ast(block);

            var t1 = new week2.IdToken(1, "while");
            var t2 = new week2.IdToken(1, "i");
            var t3 = new week2.IdToken(1, "<");
            var t4 = new week2.NumToken(1, 2);
            var tokens = new week2.Token[] { t1, t2, t3, t4 };
            var lexer = new MockLexer(tokens);
            IList<week2.ASTree> target = new List<week2.ASTree>();

            week2.ASTree result = whileParser.Parse( lexer);

            Console.WriteLine(".......................");
            Console.WriteLine( target);
            Console.WriteLine( target.Count);
            Console.WriteLine( target.GetType());
            Console.WriteLine( result.Child(0));
            

            Assert.True( result.Count == 1 );
            Assert.True( result is ASTList );
        }
    }
}


