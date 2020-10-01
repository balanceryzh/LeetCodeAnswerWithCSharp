using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.backtracking_algorithm
{
    //    全排列
    //给定一个 没有重复 数字的序列，返回其所有可能的全排列。

    //示例:

    //输入: [1,2,3]
    //    输出:
    //[
    //  [1,2,3],
    //  [1,3,2],
    //  [2,1,3],
    //  [2,3,1],
    //  [3,1,2],
    //  [3,2,1]
    //]


    public class permute
    {
        #region list
        public IList<IList<int>> Permute(int[] nums)
        {

            IList<IList<int>> list = new List<IList<int>>();

            perm(nums, 0, nums.Length - 1, list);
            return list;
        }

        public void perm(int[] nums, int left, int right, IList<IList<int>> list)
        {
            if (left == right)
            {
                IList<int> temp = new List<int>();
                for (int j = 0; j < nums.Length; j++)
                {
                    temp.Add(nums[j]);
                }
                list.Add(temp);
            }
            else
            {
                for (int i = left; i <= right; i++)
                {
                    swap(nums, i, left);
                    perm(nums, left + 1, right, list);
                    swap(nums, i, left);
                }
            }
        }

        public void swap(int[] nums, int left, int right)
        {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }
        #endregion


        //public IList<IList<int>> Permute2(int[] nums)
        //{
          

        //}
    
    }
}
