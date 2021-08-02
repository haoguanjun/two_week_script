using System;
using week2;
using week2.Ast;

namespace week2
{
    public static class BinaryExpressExtension
    {
        public static readonly int TRUE = 1;
        public static readonly int FALSE = 0;
        public static object Eval(this week2.BinaryExpress node, IEnvironment env)
        {
            string op = node.Operator;
            if (op == "=")
            {
                // 普通赋值
                object right = node.Right.Eval(env);
                return BinaryExpressExtension.ComputeAssign(node, env, right);
            }
            else
            {
                object left = node.Left.Eval(env);
                object right = node.Right.Eval(env);
                return BinaryExpressExtension.ComputeOp(node, left, op, right);
            }
        }

        public static object ComputeAssign(week2.BinaryExpress node, IEnvironment env, object rValue)
        {
            ASTree left = node.Left;
            if( left is PrimaryExpr)
            {
                PrimaryExpr expr = left as PrimaryExpr;
                if(expr.HasPostfix(0) && expr.Postfix(0) is Dot)
                {
                    Object t = (left as PrimaryExpr).EvalSubExpression(env, 1);
                    if( t is StoneObject)
                    {
                        return SetField(node, (t as StoneObject), (expr.Postfix(0) as Dot), rValue);
                    }
                }
            }
            if (left is week2.Name)
            {
                week2.Name token = left as week2.Name;
                env.Add(token.NameString(), rValue);
                return rValue;
            }
            else
            {
                throw new StoneException($"Bad assignment: {node}");
            }
        }

        public static object ComputeOp(week2.BinaryExpress node, object left, string op, object right)
        {
            if (left is int && right is int)
            {
                return BinaryExpressExtension.ComputeNumber(node, (int)left, op, (int)right);
            }
            else if (op == "+")
            {
                return $"{left}{right}";
            }
            else if (op == "==")
            {
                if (left == null)
                {
                    return right == null
                        ? 1
                        : 0;
                }
                else
                {
                    return left == right
                        ? 1
                        : 0;
                }
            }
            else
            {
                throw new StoneException($"Bad type: {node}");
            }
        }

        public static object ComputeNumber(week2.BinaryExpress node, int left, string op, int right)
        {
            switch (op)
            {
                case "+":
                    return left + right;
                case "-":
                    return left - right;
                case "*":
                    return left * right;
                case "/":
                    return left / right;
                case "%":
                    return left % right;
                case "==":
                    return left == right ? 1 : 0;
                case ">":
                    return left > right ? 1 : 0;
                case "<":
                    return left < right ? 1 : 0;
                default:
                    throw new StoneException($"Bad operator {node}");
            }
        }

        public static Object SetField(week2.BinaryExpress node, StoneObject target, Dot expr, Object rValue)
        {
            string name = expr.Name;
            try
            {
                target.Write(name, rValue);
                return rValue;
            }
            catch( AccessException exception)
            {
                throw new StoneException($"bad member access: {node.Location()} name: {name}");
            }
        }
    }
}