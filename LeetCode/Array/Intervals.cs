using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.Test
{

    //合并区间
    //给出一个区间的集合，请合并所有重叠的区间。
    //示例 1:
    //输入: intervals = [[1,3],[2,6],[8,10],[15,18]]
    //输出: [[1,6],[8,10],[15,18]]
    //解释: 区间[1, 3] 和[2, 6] 重叠, 将它们合并为[1, 6].


    public class Intervals
    {
        public int[][] Intervals1(int[][] intervals)
        {
            if(intervals.Length==0)
            {
                return intervals;
            }
            List<int[]> outlist = new List<int[]>();
            intervals = intervals.OrderBy(o => o[0]).ToArray();
            for(int i=0;i<intervals.Length-1;i++)
            {
                if(intervals[i][1]>=intervals[i+1][0])
                {
                    intervals[i + 1][0] = intervals[i][0];
                    if (intervals[i + 1][1]<= intervals[i][1])
                    {
                        intervals[i + 1][1] = intervals[i][1];
                    }
                }
                else
                {
                    outlist.Add(intervals[i]);
                }



            }
            outlist.Add(intervals[intervals.Length - 1]);
            return outlist.ToArray();


        }

        public static int[][] Intervals2(int[][] intervals)
        {
            if(intervals.Length==0)
            {
                return intervals;
            }
            List<int[]> list = new List<int[]>();
            intervals = intervals.OrderBy(o => o[0]).ToArray();
            for(int i=0;i<intervals.Length-1;i++)
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
                    list.Add(intervals[i]);
                }
            }
            list.Add(intervals[intervals.Length - 1]);
            return list.ToArray();

        }


        public static int[][] Intervals3(int[][] intervals)
        {
            if(intervals.Length==0)
            {
                return intervals;
            }
            List<int[]> outlist = new List<int[]>();
            
            intervals = intervals.OrderBy(o => o[0]).ToArray();
            for(int i=0;i<intervals.Length-1;i++)
            {
                if(intervals[i][1]>= intervals[i+1][0])
                {
                    intervals[i + 1][0] = intervals[i][0];
                    if(intervals[i][1]>=intervals[i+1][1])
                    {
                        intervals[i + 1][1] = intervals[i][1];
                    }
                }
                else
                {
                    outlist.Add(intervals[i]);
                }
            }
            outlist.Add(intervals[intervals.Length-1]);



            return outlist.ToArray();
        }
    }
}
