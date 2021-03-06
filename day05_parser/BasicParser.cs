using System.Collections.Generic;

namespace week2
{
    public class BasicParser
    {
        HashSet<string> reserved = new HashSet<string>();
        Operators operators = new Operators();
        Parser program = null;
        public BasicParser()
        {
            reserved.Add(";");
            reserved.Add("}");
            reserved.Add(Token.EOL);

            operators.Add("=", 1, Operators.RIGHT);
            operators.Add("==", 2, Operators.LEFT);
            operators.Add(">", 2, Operators.LEFT);
            operators.Add("<", 2, Operators.LEFT);
            operators.Add("+", 3, Operators.LEFT);
            operators.Add("-", 3, Operators.LEFT);
            operators.Add("*", 4, Operators.LEFT);
            operators.Add("/", 4, Operators.LEFT);
            operators.Add("%", 4, Operators.LEFT);

            Init();
        }

        public void Init()
        {
            // 空规则
            Parser expr0 = Parser.Rule();

            // ( expr0 )
            // number
            // id
            // string
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

            // -primary
            // primary
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

            // 代码块
            Parser block = Parser.Rule(typeof(BlockStmnt))
                                .Sep("{")
                                .Option(statement0)
                                .Repeat( Parser.Rule()
                                    .Sep(";", Token.EOL)
                                    .Option(statement0)
                                )
                                .Sep("}");

            Parser simple = Parser.Rule(typeof(PrimaryExpr))
                                .Ast(expr);

            // 语句
            Parser statement = statement0
                                .Or(
                                    Parser.Rule(typeof(IfStmnt))
                                        .Sep("if")
                                        .Ast(expr)
                                        .Ast(block)
                                        .Option( Parser.Rule()
                                            .Sep("else")
                                            .Ast(block)
                                    ),
                                    Parser.Rule(typeof(WhileStmnt))
                                        .Sep("while")
                                        .Ast(expr)
                                        .Ast(block),
                                    simple
                                );
            // 程序
            program = Parser.Rule()
                                .Or(
                                    statement,
                                    Parser.Rule(typeof(NullStmnt))
                                        .Sep(";", Token.EOL)
                                );
        }

        public ASTree Parse(ILexer lexer)
        {
            return program.Parse(lexer);
        }
    }
}