using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    /// <summary>
    /// 8/5
    /// </summary>
    public class ThreeSum
    {

//获取长度
//排除小于2元素
//排序
//Array.Sort()
//循环 从0到最后两位
//如果x指针>0就跳出循环
//另两个指针
//left=指针+1
//right=指针-1
//循环
//如果三个相加 = 0
//则记录
//去重
//然后 X+ Y-继续寻找
//<0则说明 要增加X
//>0则说明 要减少Y

        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int len = nums.Length;
            if (len < 3) return result;
            Array.Sort(nums);
            for (int i = 0; i < len - 2; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue; // 去重
                int left = i + 1;
                int right = len - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        result.Add(new List<int>() { nums[i], nums[left], nums[right] });
                        while (left < right && nums[left] == nums[left + 1]) left++; // 去重
                        while (left < right && nums[right] == nums[right - 1]) right--; // 去重
                        left++;
                        right--;
                    }
                    else if (sum < 0) left++;
                    else if (sum > 0) right--;
                }
            }
            return result;
        }

        public IList<IList<int>> ThreeSum3(int[] nums)
        {
            int len = nums.Length;
            var result = new List<IList<int>>();
            if (len < 3) return result;
            Array.Sort(nums);
            //map<值，lastIndex>
            var map = new Dictionary<int, int>();
            for (int i = 0; i < len; i++)
            {
                if (map.ContainsKey(nums[i])) map[nums[i]] = i;
                else map.Add(nums[i], i);
            }
            for (int i = 0; i < len - 2; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i + 1; j < len - 1; j++)
                {
                    if (j != i + 1 && nums[j] == nums[j - 1]) continue;

                    int numsK = 0 - nums[i] - nums[j];

                    if (map.ContainsKey(numsK) && map[numsK] > j)
                        result.Add(new List<int>() { nums[i], nums[j], numsK });
                }
            }
            return result;
        }



    }
}
