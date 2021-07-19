
namespace week2
{
    public class IfStmnt: ASTList
    {
        public IfStmnt(IList<ASTree> list): base( list) { }
        public ASTree Condition {
            get { return Child(0); }
        }

        public ASTree ThenBlock {
            get { return Child(1); }
        }

        public ASTree ElseBlock {
            get { 
                return Count > 2
                    ? Child(2)
                    : null;
             }
        }

        public override string ToString()
        {
            return $"(if {Condition} {ThenBlock} else {ElseBlock} )";
        }

    }
}