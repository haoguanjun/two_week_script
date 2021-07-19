
namespace week2
{
    public class Name: ASTLeaf
    {
        public Name(Token token): base( token) {}
        public string NameString() {
            return Token().Text;
        }
    }
}