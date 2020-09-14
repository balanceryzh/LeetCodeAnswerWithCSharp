using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
//    给你两个有序整数数组 nums1 和 nums2，请你将 nums2 合并到 nums1 中，使 nums1 成为一个有序数组。

 

//说明:

//初始化 nums1 和 nums2 的元素数量分别为 m 和 n 。
//你可以假设 nums1 有足够的空间（空间大小大于或等于 m + n）来保存 nums2 中的元素。
 

//示例:

//输入:
//nums1 = [1,2,3,0,0,0], m = 3
//nums2 = [2,5,6],       n = 3

//输出: [1,2,2,3,5,6]


    public class MergeTwoArray
    {
        #region test
        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            int numIndex1 = m - 1;
            int numIndex2 = n - 1;
            for (int i = m + n - 1; i >= 0; i--)
            {
                if (numIndex1 < 0)
                {
                    nums1[i] = nums2[numIndex2--];
                }
                else if (numIndex2 < 0)
                {
                    nums1[i] = nums1[numIndex1--];
                }
                else
                {
                    nums1[i] = nums1[numIndex1] > nums2[numIndex2] ? nums1[numIndex1--] : nums2[numIndex2--];
                }
            }

            
        }


        public static void Merge3(int[] nums1, int m, int[] nums2, int n)
        {
            int i = nums1.Length - 1;
            m--;
            n--;


            while (m >= 0 && n >= 0)
            {
                if (nums1[m] >= nums2[n])
                {
                    nums1[i] = nums1[m];
                    i--;
                    m--;
                }
                else
                {
                    nums1[i] = nums2[n];
                    i--;
                    n--;
                }
            }
            while (n >= 0)
            {
                nums1[i] = nums2[n];
                i--;
                n--;
            }
        }

        #endregion

        //public void Merge5(int[] nums1, int m, int[] nums2, int n)
        //{
           
            
        //}
    }
}
