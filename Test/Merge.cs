using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.Test
{
    //合并区间
    //排序
    //时间复杂度：O(nlog n)O(nlogn)
    //空间复杂度：O(log n)O(logn)
    public class Merge
    {

        public int[][] Merge1(int[][] intervals)
        {
            if (intervals.Length == 0)
            {
                return intervals;
            }

            /*基于每个区间左边界完成数组排序，保证区间左边界越小的越靠近左边。*/
            intervals = intervals.OrderBy(p => p[0]).ToArray();

            /*遍历数组，比较相邻区间是否能合并。如果左区间的右边界不小于右区间的左边界，则左右区间可以合并。*/
            List<int[]> list = new List<int[]>();


            for (int i = 0; i < intervals.Length - 1; i++)
            {
                /*
                左区间的右边界不小于右区间的左边界，则区间可以合并。将右区间作为合并后结果，
                则更新右区间的左边界为左区间的左边界。
                */
                if (intervals[i][1] >= intervals[i + 1][0])
                {
                    intervals[i + 1][0] = intervals[i][0];

                    /*左区间的右边界不小于右区间的右边界，则右区间的右边界更新为左区间的右边界。*/
                    if (intervals[i][1] >= intervals[i + 1][1])
                    {
                        intervals[i + 1][1] = intervals[i][1];
                    }
                }

                /*左区间的右边界小于右区间的左边界，则左区间不能与右区间合并，将左区间添加到结果数组中。*/
                else
                {
                    list.Add(intervals[i]);
                }
            }



            /*将数组中最后一个元素添加到结果中。*/
            list.Add(intervals[intervals.Length - 1]);

            int[][] result = list.ToArray();
            return result;
        }



        public int[][] Merge5(int[][] intervals)
        {
            List<int[]> outlist = new List<int[]>();
            intervals = intervals.OrderBy(o => o[0]).ToArray();
            for(int i=0;i<intervals.Length-1;i++)
            {
                if(intervals[i][1]>= intervals[i+1][0])
                {

                    intervals[i + 1][0] = intervals[i][0];
                    if (intervals[i][1] >= intervals[i+1][1])
                    {
                        intervals[i + 1][1] = intervals[1][1];
                    }
                }
                else
                { outlist.Add(intervals[i]); }
            }
            outlist.Add(intervals[intervals.Length - 1]);
            return outlist.ToArray();

        }

        public int[][] Merge6(int[][] intervals)
        { 
            if(intervals.Length==0)
            {
                return intervals;
            }
            intervals = intervals.OrderBy(o => o[0]).ToArray();
            List<int[]> outList = new List<int[]>();
            for(int i=0;i<intervals.Length;i++)
            {
                if(intervals[i][1]>=intervals[i+1][0])
                {
                    intervals[i + 1][0] = intervals[i][0];
                    if(intervals[i][1] >= intervals[i + 1][1])
                    {
                        intervals[i + 1][1] = intervals[i][1];
                    }
                }
                else
                {
                    outList.Add(intervals[i]);
                }
                
            }
            outList.Add(intervals[intervals.Length - 1]);
            return outList.ToArray();
        
        
        }
    }
}
