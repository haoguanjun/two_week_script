using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public static class ArgumentsExtensions
    {
        public static Object Eval(this Arguments arguments, IEnvironment calledEnv, Object value)
        {
            if( !(value is Function))
            {
                throw new StoneException($"Bad function: {arguments}");
            }
            
            Function function = value as Function;
            ParameterList parameters = function.Parameter;
            if( arguments.Size != parameters.Size())
            {
                throw new StoneException($"Bad number of function parameters. define: {arguments}, value: {parameters}");
            }

            IEnvironment newEnv = function.MakeEnv();
            int num = 0;

            // 对每个参数进行求值
            foreach(ASTree node in arguments)
            {
                // 计算实际参数的值
                object nodeValue = node.Eval(calledEnv);
                parameters.Eval(newEnv, num++, nodeValue);
            }

            BlockStmnt block = function.Body;
            var result = block.Eval(newEnv);
            return result;
        }
    }
}
