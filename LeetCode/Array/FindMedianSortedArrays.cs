using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public class FindMedianSortedArrays
    {
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
    }
}
