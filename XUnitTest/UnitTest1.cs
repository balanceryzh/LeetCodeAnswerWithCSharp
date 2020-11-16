using ConsoleTest.Sort;
using ConsoleTest.StrList;
using ConsoleTest.Test;
using ConsoleTest.tree;
using ConsoleTest.StackQeueue;
using System;
using Xunit;
using ConsoleTest.LinkTable;
using ConsoleTest;
using ConsoleTest.game;
using ConsoleTest.Hash;
using ConsoleTest.Seach;
using ConsoleTest.Dynamic_Programming;

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
            var test = LongestPalindrome.LongestPalindrome7("ccc");
            Assert.Equal("ccc", test);
        }

        [Fact]
        public void MaxSubArrayTest()
        {
            var test = MaxSubArray.MaxSubArray2(new int[] { 1, 2, 3, 4 });
            Assert.Equal(10, test);
        }

        

        [Fact]
        public void MostCommonWordTest()
        {
            var test = MostCommonWord.MostCommonWord2("Bob hit a ball, the hit BALL flew far after it was hit.",new string[] { "hit" });
            Assert.Equal("ball", test);
        }
        


        [Fact]
        public void MinMeetingRoomsTest()
        {
            int[][] test = new int[][] { new int[] { 0,30},new int[] { 5,10},new int[] {15,20 } };
            int[][] test3 = new int[][] { new int[] { 9, 10 }, new int[] { 4, 9 }, new int[] { 4, 17 } };
            var test2=   MinMeetingRooms.MinMeetingRooms3(test3);
            Assert.Equal(2,test2);
        }
        [Fact]
        public void AddStringsTest()
        {
          var test=  AddStrings20.AddStrings2("111", "222");
            Assert.Equal("333", test);
        }

        [Fact]
        public void LengthOfLongestSubstringTest()
        {
            //var test = LengthOfLongestSubstring.LengthOfLongestSubstring12("pwwkew");
            //Assert.Equal(2, test);
        }



        [Fact]
        public void Merge3Test()
        {
         MergeTwoArray.Merge3(new int[] {2,0 },1,new int[] {1 },1);
    
        }
        [Fact]
        public void ValidPalindromeTest()
        {
           
            
        }

        [Fact]
        public void CalculateTest()
        {
            var test = Calculate.Calculate2("AB");
            Assert.Equal(4, test);
        }

        [Fact]
        public void BreakfastNumber2Test()
        {
            var test = BreakfastNumber.BreakfastNumber3(new int[] { 2, 1, 1 },new int[] { 8, 9, 5, 1 },9);
            Assert.Equal(8, test);
        }


        [Fact]
        public void reorderSpacesTest()
        {
            var test = reorderSpaces.ReorderSpaces("  this   is  a sentence ");
            Assert.Equal("a", test);
        }

       //[Fact]
       //public void isAlienSorted()
       // {
       //     findKthLargest findKthLargest = new findKthLargest();
       //     findKthLargest.FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4 }, 2);
       //     var test = findKthLargest.FindKthLargest3(new int[] {3, 2, 1, 5, 6, 4},2);
       //     Assert.Equal(5, test);
       // }

        [Fact]
        public void minPathSumTest()
        {

            int[][] test = new int[][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
           var test2=  minPathSum.MinPathSum(test);
        }

        //[Fact]
        //public void ThreeSumTest()
        //{
        //}
    }
}
