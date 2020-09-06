using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Hash
{
   public  class SubarraySum
    {
//        给定一个整数数组和一个整数 k，你需要找到该数组中和为 k 的连续的子数组的个数。

//示例 1 :

//输入:nums = [1,1,1], k = 2
//输出: 2 , [1,1]
//        与[1, 1] 为两种不同的情况。


        #region test
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
        #endregion

        public int SubarraySum4(int[] nums, int k)
        {
            Dictionary<int, int> list = new Dictionary<int, int>() { { 0,1} };
            int pre = 0;int count = 0;

            for(int i=0;i<nums.Length;i++)
            {
                pre = pre + nums[i];
                if(list.ContainsKey(pre-k))
                {
                    count=count+ list[pre - k];

                }
                if(list.ContainsKey(pre))
                {
                    list[pre] = list[pre] + 1;
                }
                else
                {
                    list.Add(pre,1);
                }

            }
            return count;
        }


        public int SubarraySum5(int[] nums, int k)
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

        public int SubarraySum6(int[] nums,int k)
        {
            Dictionary<int, int> list = new Dictionary<int, int>() { {0, 1 } };
            int count = 0;int pre = 0;
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
