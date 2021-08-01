using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public static class ArgumentsWithNativeExtensions
    {
        // 普通处理
        public static Object BasicEval(this Arguments arguments, IEnvironment calledEnv, Object value)
        {
            if (!(value is Function))
            {
                throw new StoneException($"Bad function: {arguments}");
            }

            Function function = value as Function;
            ParameterList parameters = function.Parameter;
            if (arguments.Size != parameters.Size())
            {
                throw new StoneException($"Bad number of function parameters. define: {arguments}, value: {parameters}");
            }

            IEnvironment newEnv = function.MakeEnv();
            int num = 0;

            // 对每个参数进行求值
            foreach (ASTree node in arguments)
            {
                // 计算实际参数的值
                object nodeValue = node.Eval(calledEnv);
                parameters.Eval(newEnv, num++, nodeValue);
            }

            BlockStmnt block = function.Body;
            var result = block.Eval(newEnv);
            return result;
        }

        // 原生处理
        public static Object EvalWithNative(this Arguments arguments, IEnvironment env, NativeFunction nativeFunction)
        {
            int parametersCount = nativeFunction.ParametersCount;
            if (arguments.Count != parametersCount)
            {
                throw new StoneException($"Bad number of native function.");
            }
            Object[] args = new object[parametersCount];
            // 对每个参数进行求值
            for (int index = 0; index < parametersCount; index++)
            {
                // 计算实际参数的值
                ASTree node = arguments.Child(index);
                object nodeValue = node.Eval(env);

                // 如果是变量的话，需要对变量求值
                if( node is IdToken)
                {
                    nodeValue = env.Get(nodeValue as string);
                }
                args[index] = nodeValue;
            }

            // 通过反射调用方法
            Object result = nativeFunction.Invoke(args);
            return result;
        }
    }
}
