using System.Collections;
using System.Collections.Generic;

namespace week2
{
    /*
     * 抽象语法树中的叶节点
     * 叶节点没有子节点
     * 其中必须包含一个 Token
     */
    public class ASTLeaf: ASTree
    {
        // using a empty ArrayList to fullfile the requirement
        private static IList<ASTree> _empty = new List<ASTree>(0);

        // a leaf must has a token
        protected Token _token;
        
        public ASTLeaf(Token token)
        {
            _token = token;
        }

        // 不能访问叶节点的子节点
        public override ASTree Child(int index)
        {
            throw new System.IndexOutOfRangeException();
        }

        // 叶节点的子节点数量固定为 0
        public override int Count => 0;

        // 叶节点的空白迭代器
        public override IEnumerator<ASTree> Children()
        {
            return _empty.GetEnumerator();
        }

        // 返回叶节点所在行号
        public override string Location()
        {
            return $"at line {_token.LineNumber}";
        }

        // 返回叶节点中包含的 Token
        public Token Token()
        {
            return _token;
        }
        
        public override string ToString()
        {
            return _token.Text;
        }
    }
}