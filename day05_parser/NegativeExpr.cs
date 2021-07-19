
namespace week2
{
    public class NegativeExpr: ASTList
    {
        public NegativeExpr(IList<ASTree> list): base( list ) { }
        public ASTree Operand {
            get { return Child(0); }
        }
        public override string ToString()
        {
            return "-" + Operand;
        }
    }
}