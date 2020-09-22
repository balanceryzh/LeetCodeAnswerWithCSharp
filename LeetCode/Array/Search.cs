using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
   public  class search
    {
        public int Search(int[] nums, int target)
        {
            int i = 0;
            int j = nums.Length - 1;
            while (i <= j)
            {
                int mid = (i + j) / 2;
                if (nums[i] == target)
                {
                    return i;
                }
                else if (nums[j] == target)
                {
                    return j;
                }
                else if (nums[mid] == target)
                {
                    return mid;
                }
                i++;
                j--;
            }
            return -1;
        }
    }
}
