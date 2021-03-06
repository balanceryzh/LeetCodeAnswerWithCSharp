﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConsoleTest.Test
{
    //最大子序和(重点)
    //给定一个整数数组 nums ，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。

    //示例:

    //输入: [-2,1,-3,4,-1,2,1,-5,4]
    //输出: 6
    //解释: 连续子数组[4, -1, 2, 1] 的和最大，为 6。


    public class MaxSubArray
    {
#region list
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



        public static int MaxSubArray6(int[] nums)
        {
            int tempi = 0;int pre = nums[0];
            for(int i=0;i<nums.Length;i++)
            {
                tempi = Math.Max(tempi + nums[i], nums[i]);
                pre = Math.Max(pre,tempi);
            }
            return pre;
        }


        public static int MaxSubArray7(int[] nums)
        {

            int outi = 0;int outpre = nums[0];
            for(int i=0;i<nums.Length;i++)
            {
                outi = Math.Max(outi+nums[i],nums[i]);
                outpre = Math.Max(outpre,outi);
            }

            return outpre;
        }


        public static int MaxSubArray8(int[] nums)
        {
            int tempi = 0;int pre = nums[0];
            for(int i=0;i<nums.Length;i++)
            {
                tempi = Math.Max(tempi + nums[i], nums[i]);
                pre = Math.Max(tempi, pre);
            }

            return pre;
        }

#endregion
        public static int MaxSubArray9(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int pre = nums[0];
            int max = 0;
            for(int i=0;i<nums.Length;i++)
            {
                pre = Math.Max(pre, pre + nums[i]);
                max = Math.Max(max, pre);
            
            }

            return max;

        }
    }


}
