using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week2
{
    /*
     * 表示抽象语法树中的非叶节点
     * 非叶节点可能由 n 个子节点
     */
    public class ASTList : ASTree
    {
        protected IList<ASTree> _children;

        public ASTList(IList<ASTree> list)
        {
            _children = list;
        }

        public override ASTree Child(int index)
        {
            return _children[index];
        }

        public override int Count => _children.Count;

        public override IEnumerator<ASTree> Children()
        {
            return _children.GetEnumerator();
        }

        public override string Location()
        {
            foreach (var current in _children)
            {
                string location = current.Location();
                if (!System.String.IsNullOrEmpty(location))
                {
                    return location;
                }
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            string separete = " ";
            foreach(var current in _children)
            {
                builder.Append(current.ToString());
                builder.Append(separete);
            }
            builder.Append(")");
            return builder.ToString();
        }
    }
}