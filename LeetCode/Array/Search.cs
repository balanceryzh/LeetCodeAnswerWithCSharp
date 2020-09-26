using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    /// <summary>
    /// 搜索旋转数组
    /// </summary>
   public  class search
    {

        #region list
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
        #endregion


        public int Search2(int[] nums, int target)
        {

            if (nums.Length == 0) return -1;

            int left = 0;
            int right = nums.Length - 1;
            while(left<=right)
            {
                int mid = (left + right) / 2;

                if(nums[left]== target)
                {
                    return left;
                }
                else if(nums[right]==target)

                {
                    return right;
                }
                else if(nums[mid]==target)
                {
                    return mid;
                }
                left++;right--;
            }


            return -1;
        }
    }
}
