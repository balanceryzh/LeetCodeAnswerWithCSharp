using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    /// <summary>
    /// 8/4
    /// </summary>
    public class NextPermutation
    {
        public static void NextPermutation1(int[] nums)
        {
            for (int i = nums.Length - 1; i > 0; i--)
            {
                //如果和前一个元素为升序排列
                if (nums[i] > nums[i - 1])
                {
                    //则从结尾开始到i循环
                    for (int j = nums.Length - 1; j > i - 1; j--)
                    {
                        //如果j大于i-1 呼唤位置
                        if (nums[j] > nums[i - 1])
                        {
                            int temp = nums[i - 1];
                            nums[i - 1] = nums[j];
                            nums[j] = temp;
                            //如果数组还有其他元素则，作升序排列
                            if (nums.Length - i > 0)
                                Array.Sort(nums, i, nums.Length - i);
                            return;

                        }
                    }
                    break;
                }
            }
            //如果是一个降序排列则用默认排序成升序排序
            Array.Sort(nums);

        }


        #region 测试区域
        public void NextPermutation2(int[] nums)
        {
            for(int i=nums.Length-1;i>0;i--)
            {
                if(nums[i]>nums[i-1])
                {
                    for(int j=nums.Length-1;j>i-1;j--)
                    {
                        if(nums[j]>nums[i-1])
                        {
                            int temp = nums[j];
                            nums[j] = nums[i - 1];
                            nums[i - 1] = temp;
                            if (nums.Length - i > 0)
                            {
                                Array.Sort(nums, i, nums.Length - i);
                            }
                            return;
                        }
                        
                    }
                    break;
                }
            }
            Array.Sort(nums);
        }


        public void NextPermutation3(int[] nums)
        {

        }
        #endregion
    }
}
