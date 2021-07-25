using System.Collections.Generic;

namespace week2
{
    public class PrimaryExpr : ASTList
    {
        public PrimaryExpr(IList<ASTree> list) : base(list) { }
        public static ASTree create(IList<ASTree> list)
        {
            return list.Count == 1
                ? list[0]
                : new PrimaryExpr( list );
        }
    }
}