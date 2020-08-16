using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    public class FindMedianSortedArrays
    {
        public double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            int s1_Length = nums1.Length;
            int s2_Length = nums2.Length;

            if (s1_Length == 0)
            {
                if (s2_Length % 2 == 0)
                {
                    return (nums2[s2_Length / 2] + nums2[s2_Length / 2 - 1]) * 1.0 / 2;
                }
                else
                {
                    return nums2[s2_Length / 2];
                }
            }
            if (s2_Length == 0)
            {
                if (s1_Length % 2 == 0)
                {
                    return (nums1[s1_Length / 2] + nums1[s1_Length / 2 - 1]) * 1.0 / 2;
                }
                else
                {
                    return nums1[s1_Length / 2];
                }
            }

            int[] c = new int[s1_Length + s2_Length];
            int i = 0; // nums1的下标
            int j = 0; // nums2的下标
            int k = 0; // c的下标
            for (i = 0, j = 0; i < s1_Length && j < s2_Length;)
            {
                if (nums1[i] < nums2[j])
                {
                    c[k++] = nums1[i++];
                }
                else
                {
                    c[k++] = nums2[j++];
                }
            }

            while (i < s1_Length)
            {
                c[k++] = nums1[i++];
            }

            while (j < s2_Length)
            {
                c[k++] = nums2[j++];
            }

            int c_Length = c.Length;
            if (c_Length % 2 == 0)
            {
                return (c[c_Length / 2] + c[c_Length / 2 - 1]) * 1.0 / 2;
            }
            else
            {
                return c[c_Length / 2];
            }
        }


        public double FindMedianSortedArrays3(int[] nums1, int[] nums2)
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
