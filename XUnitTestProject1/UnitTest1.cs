using ConsoleTest.Test;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void LastStoneWeightIITest()
        {
           var outint= LastStoneWeightII.LastStoneWeightII1(new int[] { 2, 17, 4 });
            Assert.Equal(1, outint);
        }
    }
}
