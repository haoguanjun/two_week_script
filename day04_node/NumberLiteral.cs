
namespace week2
{
    public class NumberLiteral : ASTLeaf
    {
        public NumberLiteral(Token token) : base(token)
        {
        }

        public int Value()
        {
            return Token().Number;
        }
    }
}