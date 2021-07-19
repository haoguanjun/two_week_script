
namespace week2
{
    public class WhileStmnt: ASTList
    {
        public WhileStmnt(IList<ASTree> list): base( list ) { }
        public ASTree Condition {
            get { return Child(0); }
        }

        public ASTree Body {
            get { return Child(1); }
        }

        public override string ToString()
        {
            return $"(while ${Condition} {Body} )";
        }
    }
}