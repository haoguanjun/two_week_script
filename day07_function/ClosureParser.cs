
using System.Collections.Generic;

namespace week2
{
    public class ClosureParser
    {
        HashSet<string> reserved = new HashSet<string>();
        Operators operators = new Operators();
        Parser program = null;
        public ClosureParser()
        {
            reserved.Add(";");
            reserved.Add("}");
            reserved.Add(")");
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
                                .Repeat(Parser.Rule()
                                    .Sep(";", Token.EOL)
                                    .Option(statement0)
                                )
                                .Sep("}");
            // 简单语句
            Parser simple = Parser.Rule(typeof(PrimaryExpr))
                                .Ast(expr);

            // 语句
            Parser statement = statement0
                                .Or(
                                    Parser.Rule(typeof(IfStmnt))
                                        .Sep("if")
                                        .Ast(expr)
                                        .Ast(block)
                                        .Option(Parser.Rule()
                                            .Sep("else")
                                            .Ast(block)
                                    ),
                                    Parser.Rule(typeof(WhileStmnt))
                                        .Sep("while")
                                        .Ast(expr)
                                        .Ast(block),
                                    simple
                                );

            // add function support
            Parser param = Parser.Rule()
                .Identifier(reserved);

            // params is a key word, use @ to avoid it
            Parser @params = Parser.Rule(typeof(ParameterList))
                    .Ast(param).Repeat(
                        Parser.Rule().Sep(",").Ast(param)
                    );

            // 参数定义语法
            Parser paramList = Parser.Rule()
                        .Sep("(")
                        .Maybe(@params)
                        .Sep(")");

            Parser def = Parser.Rule(typeof(DefStmnt))
                        .Sep("def")
                        .Identifier(reserved)
                        .Ast(paramList)
                        .Ast(block);

            // 实际参数语法
            Parser args = Parser.Rule(typeof(Arguments))
                        .Ast(expr)
                        .Repeat(
                            Parser.Rule().Sep(",").Ast(expr)
                        );
            // 实际参数可能在括号内
            Parser postfix = Parser.Rule()
                        .Sep("(")
                        .Maybe(args)
                        .Sep(")");

            primary.Repeat(postfix);

            // 基本语句增加了支持括号带参数
            simple.Option(args);

            // 在支持闭包的情况下，简单语句现在有了两种情况
            simple.InsertChoice(
                Parser.Rule(typeof(ClosureFunction))
                    .Sep("function")
                    .Ast(paramList)
                    .Ast(block)
                );

            // 程序
            // 注意定义函数的定义，需要放在最前面
            program = Parser.Rule()
                                .Or(
                                    def,
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
