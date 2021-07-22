using System;
using System.Collections.Generic;

namespace week2.element
{
    /*
     * 解析器的语法规则元素
     * 核心任务
     *   解析来自词法分析器的 Token 为抽象语法树的节点
     *   检查来自词法分析器的 Token 是非适用本语法规则元素进行处理 
     */
    public abstract class Element
    {
        public abstract void Parse(Lexer lexer, IList<ASTree> res);
        public abstract bool Match(Lexer lexer);
    }
}
