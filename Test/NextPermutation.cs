using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    public class NextPermutation
    {
        public void NextPermutation1(int[] nums)
        {
            for(int i= nums.Length-1; i>0;i--)
            {
                if(nums[i]>nums[i-1])
                {
                    for(int j=nums.Length-1;j>i;j--)
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


        public void NextPermutation4(int[] nums)
        {
            for(int i=nums.Length-1;i>0;i--)
            {
                if(nums[i]>nums[i-1])
                {
                    for(int j= nums.Length - 1; j > i-1; j--)
                    {
                      if(nums[i-1]>nums[j])
                        {
                            if(nums.Length-i>0)
                            {
                                Array.Sort(nums, i, nums.Length - i);
                            }
                        }
                    }
                }
            }
        }
    }
}
