using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
//    给你 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点(i, ai) 。在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为(i, ai) 和(i, 0)。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。

//说明：你不能倾斜容器，且 n 的值至少为 2。
//输入：[1,8,6,2,5,4,8,3,7]
//输出：49

   public  class maxArea
   {

        #region list
        public int MaxArea2(int[] height)
        {
            int max = 0; 
            for (int i=0;i<height.Length;i++)
            {
                if (i + 1 < height.Length)
                {
                    for (int j = i + 1; j < height.Length; j++)
                    {
                        if(height[j]>=height[i]&&max< (j - i) * height[i])
                        {
                            max = (j - i) * height[i];
                        }
                        else if(height[j] < height[i] && max < (j - i) * height[j])
                        {
                            max = (j - i) * height[j];
                        }
                    }
                }
            }
            return max;
        }


        public int MaxArea3(int[] height)
        {
            int left = 0; int right = height.Length - 1; int max = 0;

            while (left < right && height.Length > 1)
            {
                int h = Math.Min(height[left], height[right]);
                max = Math.Max(max, h * (right - left));
                if (height[left] > height[right]) right--;
                else left++;
            }
            return max;
        }
        #endregion


        //public int MaxArea(int[] height)
        //{




        //}

    }
}

