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


    public class Merge
    {
        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            int z = m + n;
            int tempi = 0;
            for (int j = m; j < z; j++)
            {
                if (tempi < n)
                {
                    nums1[j] = nums2[tempi];
                    tempi++;
                }
            }
            for (int i = 0; i < z; i++)
            {
                for (int j = i; j < z; j++)
                {
                    if (nums1[j] <= nums1[i])
                    {
                        int temp = nums1[j];
                        nums1[j] = nums1[i];
                        nums1[i] = temp;
                    }
                }
            }
        }


        public void Merge3(int[] nums1, int m, int[] nums2, int n)
        {

        }

    }
}
