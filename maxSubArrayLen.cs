using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    public class maxSubArrayLen325
    {
//////给定一个数组 nums 和一个目标值 k，找到和等于 k 的最长子数组长度。如果不存在任意一个符合要求的子数组，则返回 0。

//////注意:
////// nums 数组的总和是一定在 32 位有符号整数范围之内的。

//////示例 1:

//////输入: nums = [1, -1, 5, -2, 3], k = 3
//////输出: 4 
//////解释: 子数组[1, -1, 5, -2] 和等于 3，且长度最长。
//////示例 2:

//////输入: nums = [-2, -1, 2, 1], k = 1
//////输出: 2 
//////解释: 子数组[-1, 2] 和等于 1，且长度最长。


        public int maxSubArrayLen(int[] nums, int k)
        {
            int sum = 0, res = 0;
            var list = new Dictionary<int, int>();
            for(int i=0;i< nums.Length;i++)
            {
                sum = sum + nums[i];
                if (sum == k)
                { res = i + 1; }
                else if (list.ContainsKey(sum-k))
                {
                    //将长度和hash存放的值长度比较
                    res = Math.Max(res, i - list[sum-k]);
                }
                if(!list.ContainsKey(sum))
                {
                    list.Add(sum, i);
                }

            }
            return res;
        }
    }
}
