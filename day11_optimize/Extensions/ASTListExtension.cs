using System;
using week2;

namespace week2
{
    public static class ASTListExtension
    {
        public static void PreProcess(this ASTList list, Symbols symbols)
        {
            // 对每个子节点进行预处理
            foreach(ASTree node in list)
            {
                node.PreProcess(symbols);
            }
        }

        public static object Eval(this week2.ASTList list, IOptimizeEnvironment env)
        {
            throw new StoneException($"Cann't eval: {list}");
        }
    }
}