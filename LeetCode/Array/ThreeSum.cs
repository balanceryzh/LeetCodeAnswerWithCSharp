using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleTest
{
    /// <summary>
    /// 三数之和
    /// </summary>
    /// 
//    给你一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？请你找出所有满足条件且不重复的三元组。

//注意：答案中不可以包含重复的三元组。

 

//示例：

//给定数组 nums = [-1, 0, 1, 2, -1, -4]，

//满足要求的三元组集合为：
//[
//  [-1, 0, 1],
//  [-1, -1, 2]
//]

    public class threeSum
    {
        #region list
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int len = nums.Length;
            if (len < 3) return result;
            Array.Sort(nums);

            for (int i = 0; i < len - 2; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue; // 去重

                int left = i + 1;
                int right = len - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        result.Add(new List<int>() { nums[i], nums[left], nums[right] });
                        while (left < right && nums[left] == nums[left + 1]) left++; // 去重
                        while (left < right && nums[right] == nums[right - 1]) right--; // 去重
                        left++;
                        right--;
                    }
                    else if (sum < 0) left++;
                    else if (sum > 0) right--;
                }
            }
            return result;

        }
        #endregion

        //public static IList<IList<int>> ThreeSum2(int[] nums)
        //{
           

        //}

    }
}
