using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    public class MaxSubArray
    {
        public int MaxSubArray1(int[] nums)
        {
            int tempi = 0; int pre = nums[0];

            foreach (int i in nums)
            {
                tempi = Math.Max(tempi + i, i);

                pre = Math.Max(pre, tempi);

            }
            return pre;
        }
    }


}
