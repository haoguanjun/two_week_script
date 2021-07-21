using System.Collections.Generic;

namespace week2
{
    /*
     * 抽象语法树中的二值表达式，例如 a + b
     * 内部使用了一个列表来保存子节点
     * 0: 左子节点
     * 2: 右子节点
     * 1: 操作符
     */ 
    public class BinaryExpress: ASTList
    {
        public BinaryExpress(IList<ASTree> list): base( list) {}
        public ASTree Left
        {
            // define the left at 0
            get { return _children[0]; }
        }
        public ASTree Right
        {
            get { return _children[2];}
        }

        public string Operator
        {
            get { 
                ASTLeaf leaf = _children[1] as ASTLeaf;
                return leaf.Token().Text; }
        }
    }
}