
namespace week2
{
    /*
     * 数值子节点
     */
    public class NumberLiteral : ASTLeaf
    {
        public NumberLiteral(Token token) : base(token) { }

        public int Value()
        {
            return Token().Number;
        }
    }
}