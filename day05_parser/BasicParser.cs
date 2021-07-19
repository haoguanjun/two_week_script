using System.Collections.Generic;

namespace week2
{
    public class BasicParser
    {
        HashSet<string> reserved = new HashSet<string>();
        Operators operators = new Operators();
        Parser expr0 = rule();

        Parser primary = rule(typeof(PrimaryExpr))
            .or(rule()
                    .sep("(")
                    .ast(expr0)
                    .sep(")"),
                rule()
                    .number(typeof(NumberLiteral)),
                rule()
                    .identifier(typeof(Name), reserved),
                rule()
                    .string(typeof(StringLiteral))
            );

        Parser factor = rule()
                        .or(rule(typeof(NegativeExpr))
                            .sep("-")
                            .ast(primary),
                            primary
                        );

        Parser expr = expr0
                        .expression(typeof(BinaryExpress), factor, operators);

        Parser statement0 = rule();

        Parser block = rule(typeof(BlockStmnt))
                            .sep("{")
                            .option(statement0)
                            .repeat(rule()
                                .sep(";", Token.HOL)
                                .option(statement0)
                            )
                            .sep("}");

        Parser simple = rule(typeof(PrimaryExpr))
                            .ast(expr);

        Parser statement = statement0
                            .or(
                                rule(typeof(IfStmnt))
                                    .sep("if")
                                    .ast(expr)
                                    .ast(block)
                                    .option(rule()
                                        .sep("else")
                                        .ast(block)
                                ),
                                rule(typeof(WhileStmnt))
                                    .sep("while")
                                    .ast(expr)
                                    .ast(block),
                                simple
                            );
        Parser program = rule()
                            .or(
                                statement,
                                rule(typeof(NullStmnt))
                                    .sep(";", Token.HOL)
                            );

        public BasicParser()
        {
            reserved.Add(";");
            reserved.Add("}");
            reserved.Add(Token.HOL);

            operators.Add("=", 1, operators.RIGHT);
            operators.Add("==", 2, operators.LEFT);
            operators.Add(">", 2, operators.LEFT);
            operators.Add("<", 2, operators.LEFT);
            operators.Add("+", 2, operators.LEFT);
            operators.Add("-", 2, operators.LEFT);
            operators.Add("*", 2, operators.LEFT);
            operators.Add("/", 2, operators.LEFT);
            operators.Add("%", 2, operators.LEFT);
        }

        public ASTree Parse(Lexer lexer)
        {
            return program.Parse(lexer);
        }
    }
}