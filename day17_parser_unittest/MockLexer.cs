using System;
using week2;

namespace day17_parser_unittest
{
    public class MockLexer : week2.ILexer
    {
        public Token[] _tokens;
        private int _index = 0;
        public MockLexer(Token instance)
        {
            _tokens = new week2.Token[] { instance };
        }

        public MockLexer(Token[] tokens)
        {
            _tokens = tokens;
        }

        public Token Read()
        {
            
            if( _index >= _tokens.Length ) return null;
            return _tokens[_index++];
        }

        public Token Peek(int index)
        {
            if( _index >= _tokens.Length ) return null;
            return _tokens[ _index + 1 ];
        }
    }
}