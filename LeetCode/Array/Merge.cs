using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
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

    }
}
