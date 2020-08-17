using ConsoleTest.Sort;
using ConsoleTest.Test;
using System;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void InsertSortTest()
        {
            var test=  InsertSort.insertSortTest3(new int[] {5,17,6 });
            Assert.Equal(new int[] { 17, 6, 5 }, test);
        }
        [Fact]
        public void IntervalsTest()
        {
            var intervals = new int[][]{ new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 }};
            var test = Intervals.Intervals2(intervals);
            Assert.Equal(new int[][] { new int[] { 1, 6 },new int[] { 8, 10 }, new int[] { 15, 18 } }, test);
        }

        [Fact]
        public void SpiralOrderTest()
        {
            var intervals = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            var test = SpiralOrder.SpiralOrder5(intervals);
            Assert.Equal(new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 }, test);
        }


        [Fact]
        public void ProductExceptSelfTest()
        {
            var test = ProductExceptSelf.ProductExceptSelf7(new int[] { 1, 2, 3, 4 });
            Assert.Equal(new int[] { 24, 12, 8, 6 }, test);
        }

        [Fact]
        public void LongestPalindromeTest()
        {
            var test = LongestPalindrome.LongestPalindrome7("aabc");
            Assert.Equal("aa", test);
        }

        [Fact]
        public void MaxSubArrayTest()
        {
            var test = MaxSubArray.MaxSubArray2(new int[] { 1, 2, 3, 4 });
            Assert.Equal(10, test);
        }
    }
}
