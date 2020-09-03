using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Hash
{
   public  class SubarraySum
    {
        public int SubarraySum2(int[] nums, int k)
        {
            int count = 0, pre = 0;
            Dictionary<int, int> dict = new Dictionary<int, int> { { 0, 1 } };
            for (int i = 0; i < nums.Length; i++)
            {
                pre += nums[i];
                if (dict.ContainsKey(pre - k))
                    count += dict[pre - k];

                if (dict.ContainsKey(pre))
                {
                    dict[pre]++;
                }
                else
                {
                    dict.Add(pre, 1);
                }
            }

            return count;
        }

        public int SubarraySum3(int[] nums,int k)
        {
            int count = 0;int pre = 0;
            Dictionary<int, int> list = new Dictionary<int, int>() { { 0, 1 } };
            for(int i=0;i<nums.Length;i++)
            {
                pre = pre + nums[i];

                if(list.ContainsKey(pre-k))
                {
                    count = count + list[pre - k];
                }
                if(list.ContainsKey(pre))
                {
                    list[pre]++;
                }
                else
                {
                    list.Add(pre, 1);

                }


            }

            return count;
        }

    }
}
