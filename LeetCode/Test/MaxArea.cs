using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{ 
   public  class MaxArea
   {

   
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
    }
}

