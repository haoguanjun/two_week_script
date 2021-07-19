
namespace week2
{
    public class StringLiteral: ASTLeaf
    {
        public StringLiteral(Token token): base( token ) { }
        public string Value {
            get { _token.Text; }
        }
    }
}