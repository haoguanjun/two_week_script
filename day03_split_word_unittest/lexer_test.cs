using System;
using System.Text.RegularExpressions;
using Xunit;

namespace project_test
{
    public class Lexer_Test
    {
        Regex regex = null;
        string regexString = "\\s*((//.*)|([0-9]+)|(\"(\\\\\"|\\\\\\\\|\\\\\n|[^\"])*\")|[A-Z_a-z][A-Z_a-z0-9]*|==|<=|>=|&&|\\|\\||[\\p{S}\\p{P}])?";
        public Lexer_Test()
        {
            regex = new Regex(regexString);
        }

        [Fact]
        public void number_test()
        {
            var target = "100";
            var matches = regex.Matches(target);
            Assert.True( matches[0].Groups[3].Success);
        }

        [Fact]
        public void string_test()
        {
            var target = "\"sum\"";
            var matches = regex.Matches(target);
            Assert.True( matches[0].Groups[4].Success);
        }
        [Fact]
        public void statement_test()
        {
            var target = "sum=100";
            var matches = regex.Matches(target);

            Assert.NotEmpty(matches);
            Assert.Equal<int>(4, matches.Count);
        }
    }
}