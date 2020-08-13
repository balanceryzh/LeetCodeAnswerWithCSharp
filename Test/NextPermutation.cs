using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
//以下是一些例子，输入位于左侧列，其相应输出位于右侧列。
//1,2,3 → 1,3,2
//3,2,1 → 1,2,3
//1,1,5 → 1,5,1
//1,2,3,1-> 1,1,3,2

    public class NextPermutation
    {
        public void NextPermutation1(int[] nums)
        {
            for(int i=nums.Length-1;i>0;i--)
            {
                if(nums[i]>nums[i-1])
                {
                    int temp = nums[i - 1];

                    for(int j = nums.Length - 1; j > i - 1; j--)
                    {
                        if(temp<=nums[j])
                        {
                            nums[i - 1] = nums[j];
                            nums[j] = temp;
                            if(nums.Length - i>0)
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
        public void NextPermutation2(int[] nums)
        {
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] > nums[i - 1])
                {
                    for (int j = nums.Length - 1; j > i - 1; j--)
                    {
                        if (nums[j] > nums[i - 1])
                        {
                            int temp = nums[i - 1];
                            nums[i - 1] = nums[j];
                            nums[j] = temp;
                            if (nums.Length - i > 0)
                                Array.Sort(nums, i, nums.Length - i);
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

            for(int i=nums.Length-1;i>0;i--)
            {
              if(nums[i]>nums[i-1])
                {
                    int temp = i - 1;
                    for(int j=nums.Length;j> temp;j--)
                    {
                        if(nums[temp]<nums[j])
                        {
                            int tempval = nums[temp];
                            nums[temp] = nums[j];
                            nums[j] = tempval;
                            if(nums.Length - i>0)
                            {
                                Array.Sort(nums, i, nums.Length - i );
                                return;
                            }
                        }
                    }

                }
            }
            Array.Sort(nums);
        }



    }
}
