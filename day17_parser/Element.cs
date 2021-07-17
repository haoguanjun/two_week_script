using System;
using System.Collections.Generic;

namespace Parser
{
    /*
     * 抽象类
     */
    public abstract class Element
    {
        protected abstract void Parse(Lexer lexer, IList<ASTree> res);
        protected abstract bool Match(Lexer lexer);
    }
}
