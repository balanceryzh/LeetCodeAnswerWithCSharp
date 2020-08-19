using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConsoleTest.Test
{
    //最大子序和
    //给定一个整数数组 nums ，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。

    //示例:

    //输入: [-2,1,-3,4,-1,2,1,-5,4]
    //输出: 6
    //解释: 连续子数组[4, -1, 2, 1] 的和最大，为 6。


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


        public int MaxSubArray3(int[] nums)
        {
            int tempi = 0;int pre = nums[0];
                foreach(int i in nums)
                {
                tempi = Math.Max(tempi+i,i);
                pre = Math.Max(pre, tempi);
                }

                return pre;

        }


        public static int MaxSubArray2(int[] nums)
        {
            int tempi = 0;int pre = nums[0];
            foreach(int i in nums)
            {
                tempi = Math.Max(tempi + i, i);
                pre = Math.Max(tempi, pre);
            }
            return pre;
        }

        public static int MaxSubArray5(int[] nums)
        {
            int tempi = 0;int pre = nums[0];

            for(int i=0;i<nums.Length;i++)
            {
                tempi = Math.Max(tempi+i,i);
                pre = Math.Max(tempi,pre);

            }
            return pre;
        }

    }


}
