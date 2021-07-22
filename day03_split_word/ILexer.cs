namespace week2
{
    public interface ILexer
    {
        public Token Read();
        public Token Peek(int index);
    }
}