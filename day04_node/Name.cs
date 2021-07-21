
namespace week2
{
    /*
     * 表示变量名称的子节点
     */
    public class Name: ASTLeaf
    {
        public Name(Token token): base( token) {}
        public string NameString() {
            return Token().Text;
        }
    }
}