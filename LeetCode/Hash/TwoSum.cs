using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleTest
{
//    给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。

//你可以假设每种输入只会对应一个答案。但是，数组中同一个元素不能使用两遍。

 

//示例:

//给定 nums = [2, 7, 11, 15], target = 9

//因为 nums[0] + nums[1] = 2 + 7 = 9
//所以返回[0, 1]

    public class TwoSum
    {


        #region Test
        /// <summary>
        /// leecode1 速度最快 内存使用更多需要引用System.Collections.Generic
        /// </summary>
        public int[] TwoSum1(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i]))
                {
                    return new int[] { dict[target - nums[i]], i };
                }
                else if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
            throw new ArgumentException("No solution");
        }

        /// <summary>
        /// 我的解答 内存适中 速度比上面慢了不少
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum2(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int z = nums[i] + nums[j];
                    if (z == target)
                    {

                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { 0, 0 };
        }
        /// <summary>
        /// 内存最小但速度很慢需要引用linq
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum3(int[] nums, int target)
        {
            List<int> result = new List<int>();
            for (var i = 0; i < nums.Count(); i++)
            {
                var a = nums[i];
                for (var j = i + 1; j < nums.Count(); j++)
                {
                    var b = nums[j];
                    if (a + b == target)
                    {
                        result.Add(i);
                        result.Add(j);
                        break;
                    }
                }
            }

            return result.ToArray();
        }

        public int[] TwoSum5(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            for(int i=0;i<nums.Length;i++)
            {
                if(dic.ContainsKey(target-nums[i]))
                {
                    return new int[] { dic[target - nums[i]], i };
                }
                else if(!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], i);

                }


            }
            throw new ArgumentException("No solution");

        }


        public int[] TwoSum6(int[] nums, int target)
        {
            var dlc = new Dictionary<int, int>();
            for(int i=0;i<nums.Length;i++)
            {
                if(dlc.ContainsKey(target- nums[i]))
                {
                    return new int[] { dlc[target - nums[i]], i };
                }
                else if(!dlc.ContainsKey(nums[i]) )
                {

                    dlc.Add(nums[i], i);
                }
            }
            throw new ArgumentException("");
;        }

        #endregion

        #region 2020/10/21
        public int[] TwoSum7(int[] nums, int target)
        {
            Dictionary<int,int> temp = new Dictionary<int, int>();
            for(int i=0;i<nums.Length;i++)
            {
                if(temp.ContainsKey(target-nums[i]))
                {

                    return new int[] { temp[target - nums[i]], i };
                }
                else
                {
                    if (!temp.ContainsKey(nums[i]))
                    {
                        temp.Add(nums[i], i);
                    }
                }
            }
            throw new FieldAccessException("no");
        }
        #endregion
        //public int[] TwoSum8(int[] nums, int target)
        //{

        //}

    }
}
