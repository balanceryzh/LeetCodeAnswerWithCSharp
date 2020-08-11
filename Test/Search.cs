using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    /// <summary>
    /// 8/5
    /// </summary>
    public class Search
    {
      
            public int Search1(int[] nums, int target)
            {
              
                int x = 0;
                int y = nums.Length - 1;
                while (x <= y)
                {
                    if (target == nums[x])
                    {
                        return x;
                    }
                    if (target == nums[y])
                    {
                        return y;
                    }
                    if (target > nums[x])
                    {
                        x++;
                    }
                    else if (target < nums[y])
                    {
                        y--;
                    }
                    else
                    {
                    return -1;
                    }
                }
                return -1;
            }
             public int Search2(int[] nums, int target)
            {
                if (nums.Length == 0)
                return -1;
                int low = 0, high = nums.Length - 1, top = nums[0];
                int mid = (low + high) / 2;
                while (low <= high)
                {
                    ///和我理解的区别
                    if (nums[mid] == target) return mid;
                    if (target < top)
                    {
                        if (nums[mid] < top && nums[mid] > target)
                            high = mid - 1;
                         else
                            low = mid + 1;
                    }
                    else
                    {
                        if (nums[mid] >= top && nums[mid] <= target)
                            low = mid + 1;
                        else
                            high = mid - 1;
                 }

                     mid = (low + high) / 2;

            }
            return -1;
        }
    }
}
