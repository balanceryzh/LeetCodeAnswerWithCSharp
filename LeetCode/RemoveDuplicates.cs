using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public class RemoveDuplicates
    {
        public static int RemoveDuplicatesTest(int[] nums)
        {
            if(nums.Length<1)
            {
                return 0;
            }
            int temp = nums[0];
            int outLength = 1;
            int j = nums.Length;
            for (int i = 1; i <j; i++)
            {
                if (temp == nums[i])
                {
                    Duplicates(ref nums, i);
                    i = i - 1;
                    j = j - 1;
                }
                else
                {
                    outLength = outLength + 1;
                    temp = nums[i];
                }
            }
            return outLength;
        }

        public static int[] Duplicates(ref int[] nums, int temp)
        {
            int tempInt = nums[temp];
            for (int i = temp; i < nums.Length; i++)
            {
                if (i == nums.Length - 1)
                {
                    nums[i] = tempInt;
                }
                else
                {
                    nums[i] = nums[i + 1];
                }
            }
            return nums;

        }

        public static int RemoveDuplicates2(int[] nums)
        {

            int i = 0;

            if (nums.Length == 0)
            {
                return 0;
            }

            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }
    }
}
