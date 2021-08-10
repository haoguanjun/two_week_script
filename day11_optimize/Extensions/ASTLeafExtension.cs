using System;
using week2;

namespace week2
{
    public static class ASTLeafExtension
    {
        public static object Eval(this ASTLeaf leaf, IOptimizeEnvironment env)
        {
            throw new StoneException($"Cann't eval: {leaf}");
        }
    }
}