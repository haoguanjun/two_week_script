using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public static class ArgumentsExtensions
    {
        public static Object Eval(this Arguments arguments, IOptimizeEnvironment calledEnv, Object value)
        {
            if (value is OptFunction func)
            {
                return ProcessFunction(func, arguments, calledEnv);
            }
            else if (value is NativeFunction nativeFunc)
            {
                return ProcessNativeFunction(nativeFunc, arguments, calledEnv);
            }
            else
            {
                throw new StoneException($"Bad function: {arguments}");
            }
        }

        // 普通函数
        public static Object ProcessFunction(Function function, Arguments arguments, IOptimizeEnvironment env)
        {
            ParameterList parameters = function.Parameter;
            if (arguments.Size != parameters.Size())
            {
                throw new StoneException($"Bad number of function parameters. define: {arguments}, value: {parameters}");
            }

            IOptimizeEnvironment newEnv = function.MakeEnv();
            int num = 0;

            // 对每个参数进行求值
            foreach (ASTree node in arguments)
            {
                // 计算实际参数的值
                object nodeValue = node.Eval(env);
                parameters.Eval(newEnv, num++, nodeValue);
            }

            BlockStmnt block = function.Body;
            var result = block.Eval(newEnv);
            return result;
        }

        // 原生函数
        public static Object ProcessNativeFunction(NativeFunction nativeFunction, Arguments arguments, IOptimizeEnvironment env)
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
                args[index] = nodeValue;
            }

            // 通过反射调用方法
            Object result = nativeFunction.Invoke(args);
            return result;
        }
    }
}