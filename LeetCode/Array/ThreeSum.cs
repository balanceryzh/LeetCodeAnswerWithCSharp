using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public class threeSum
    {

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            for (int k = 0; k < nums.Length - 2; k++)
            {
                if (nums[k] > 0) break;
                if (k > 0 && nums[k] == nums[k - 1]) continue;
                int i = k + 1;
                int j = nums.Length - 1;
                while (i < j)
                {
                    int sum = nums[k] + nums[i] + nums[j];
                    if (sum < 0)
                        while (i < j && nums[i] == nums[++i]) ;
                    else if (sum > 0)
                        while (i < j && nums[j] == nums[--j]) ;
                    else
                    {
                        IList<int> item = new List<int>();
                        item.Add(nums[k]);
                        item.Add(nums[i]);
                        item.Add(nums[j]);
                        res.Add(item);
                        while (i < j && nums[i] == nums[++i]) ;
                        while (i < j && nums[j] == nums[--j]) ;
                    }

                }
            }
            return res;

        }
    }
}
