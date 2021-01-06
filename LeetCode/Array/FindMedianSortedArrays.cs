using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace ConsoleTest
{
    //寻找两个正序数组的中位数
//    给定两个大小为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。请你找出并返回这两个正序数组的中位数。

//进阶：你能设计一个时间复杂度为 O(log (m+n)) 的算法解决此问题吗？

 

//示例 1：

//输入：nums1 = [1,3], nums2 = [2]
//    输出：2.00000
//解释：合并数组 = [1,2,3] ，中位数 2
//示例 2：

//输入：nums1 = [1,2], nums2 = [3,4]
//    输出：2.50000
//解释：合并数组 = [1,2,3,4] ，中位数(2 + 3) / 2 = 2.5
//示例 3：

//输入：nums1 = [0,0], nums2 = [0,0]
//    输出：0.00000
//示例 4：

//输入：nums1 = [], nums2 = [1]
//    输出：1.00000
//示例 5：

//输入：nums1 = [2], nums2 = []
//    输出：2.00000


    public class FindMedianSortedArrays
    {
        #region list
        public double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            int lastNum = int.MinValue;
            int cur = int.MinValue;

            int sum = (nums1 != null ? nums1.Length : 0) + (nums2 != null ? nums2.Length : 0);

            bool isOddNum = sum % 2 != 0;
            int tarIndex = isOddNum ? (sum - 1) / 2 : sum / 2;

            int index1 = 0;
            int index2 = 0;
            int curIndex = 0;
            while (true)
            {
                if (nums1 == null || index1 >= nums1.Length)
                {
                    lastNum = cur;
                    cur = nums2[index2];
                    index2++;
                }
                else if (nums2 == null || index2 >= nums2.Length)
                {
                    lastNum = cur;
                    cur = nums1[index1];
                    index1++;
                }
                else
                {
                    lastNum = cur;
                    if (nums1[index1] < nums2[index2])
                    {
                        cur = nums1[index1];
                        index1++;
                    }
                    else
                    {
                        cur = nums2[index2];
                        index2++;
                    }
                }
                if (curIndex == tarIndex)
                {
                    if (isOddNum)
                        return cur;
                    else
                        return lastNum + ((cur - lastNum) / 2.0f);
                }
                curIndex++;
            }
        }
        #endregion


        public double FindMedianSortedArrays3(int[] nums1, int[] nums2)
        {
            int last = 0, first = 0;
            int sum = (nums1 == null ? 0 : nums1.Length) + (nums2 == null ? 0 : nums2.Length);

            bool isOddNum = sum % 2 != 0;

            int midIndex = isOddNum ? (sum - 1) / 2 : sum / 2;
            int nowIndex = 0;

            int index1 = 0;
            int index2 = 0;
            while (true)
            {
                if(nums1==null|| index1 > nums1.Length)
                {
                    last = first;
                    first = nums2[index2];
                    index2++;
                }
                else if(nums2==null|| index2 > nums2.Length)
                {
                    last = first;
                    first = nums1[index1];
                    index1++;
                }
                else
                {
                    last = first;
                    if(nums1[index1]>nums2[index2])
                    {

                        first = nums1[index1];
                        index1++;
                    }
                    else
                    {
                        first = nums2[index2];
                        index2++;
                    }

                }

                if(nowIndex== midIndex)
                {
                    if(isOddNum)
                    {
                        return first;
                    }
                    else
                    {
                        return (first + last) / 2.0f;
                    }

                }


                nowIndex++;
            }


        }
    }
}
