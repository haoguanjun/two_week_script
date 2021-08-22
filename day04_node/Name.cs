namespace week2
{
    /*
     * 表示变量名称的子节点
     */
    public class Name : ASTLeaf
    {
        public static readonly int UNKNOWN = -1;
        public int Index { get; set; }
        public int Nest { get; set; }

        public Name(Token token) : base(token)
        {
            Index = UNKNOWN;
        }
        public string NameString()
        {
            return Token().Text;
        }
    }
}