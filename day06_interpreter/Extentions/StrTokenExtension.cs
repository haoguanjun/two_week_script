using System;
using week2;

namespace week2
{
    public static class StrTokenExtension
    {
        public static object Eval(this StrToken token, IEnvironment env)
        {
            return token.Text;
        }
    }
}