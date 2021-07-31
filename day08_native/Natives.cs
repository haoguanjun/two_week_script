using System;

namespace week2
{
    public class Natives
    {
        public IEnvironment SetEnvironment( IEnvironment env)
        {
            AppendNatives(env);
            return env;
        }

        // 在环境中添加原生方法支持
        public void AppendNatives(IEnvironment env)
        {
            Append(env, "Print", typeof(Natives), typeof(Object));
            Append(env, "Read", typeof(Natives));
            Append(env, "Length", typeof(Natives), typeof(String));
            Append(env, "ToInt32", typeof(Natives), typeof(Object));
            Append(env, "Now", typeof(Natives));
        }

        public void Append(IEnvironment env, string methodName, Type target, params Type[] parameters)
        {
            System.Reflection.MethodInfo methodInfo = null;
            try
            {
                methodInfo = target.GetMethod(methodName, parameters);
            }
            catch( Exception exception)
            {
                throw new StoneException($"Can't find method {methodName} in {target}.");
            }
            env.Add(methodName, new NativeFunction(methodName, methodInfo));
        }

        // native method
        public static int Print(Object obj)
        {
            System.Console.WriteLine($"Native Calling");
            System.Console.WriteLine(obj);
            return 0;
        }

        public static String Read()
        {
            return System.Console.ReadLine();
        }

        public static int Length(string message)
        {
            return message.Length;
        }

        public static int ToInt32(Object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static string Now()
        {
            return DateTime.UtcNow.ToLongDateString();
        }

    }

}