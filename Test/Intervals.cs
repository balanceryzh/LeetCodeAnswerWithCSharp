using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.Test
{
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
    }
}
