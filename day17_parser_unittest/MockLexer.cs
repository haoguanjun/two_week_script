using week2;

namespace day17_parser_unittest
{
    public class MockLexer : week2.ILexer
    {
        public Token MockToken { get; private set; }
        public MockLexer(Token instance)
        {
            MockToken = instance;
        }

        public Token Read()
        {
            return MockToken;
        }

        public Token Peek(int index)
        {
            return MockToken;
        }
    }
}