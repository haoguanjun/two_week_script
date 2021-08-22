using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week2.Ast;

namespace week2
{
    public static class DotExtensions
    {
        public static Object Eval(this Dot dot, IOptimizeEnvironment env, Object value)
        {
            string member = dot.Name;
            if (value is ClassInfo)
            {
                if (member == "new")
                {
                    ClassInfo info = value as ClassInfo;
                    ResizableArrayEnvironment e = new ResizableArrayEnvironment(info.Environment);
                    StoneObject obj = new StoneObject(e);
                    e.Add("this", obj);
                    InitObj(info, e);
                    return obj;
                }
            }
            else if (value is StoneObject)
            {
                try
                {
                    StoneObject target = value as StoneObject;
                    return target.Read(member);
                }
                catch (AccessException exception)
                {
                    Console.WriteLine($"Access error");
                }

            }
            throw new StoneException($"bad member access: {member}");
        }

        public static void InitObj(ClassInfo info, IOptimizeEnvironment env)
        {
            if (info.BaseClass != null)
            {
                InitObj(info.BaseClass, env);
            }
            info.Body.Eval(env);
        }
    }
}