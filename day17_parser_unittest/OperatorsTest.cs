using System;
using System.Collections.Generic;
using Xunit;
using week2;

namespace day17_parser_unittest
{
    public class OperatorsTest
    {
        [Fact]
        public void Operators_Test_Get()
        {
            Operators map = new Operators();
            map.Add("+", 2, Operators.LEFT);

            Precedence target = map.Get("+");

            Assert.Equal(target.Value, 2);
            Assert.True(target.LeftAssoc);
        }
    }
}