using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    public class ProductExceptSelf
    {
        //空间复杂度 O(1) 的方法
        public int[] ProductExceptSelf1(int[] nums)
        {
            int length = nums.Length;
            int[] answer = new int[length];

            // answer[i] 表示索引 i 左侧所有元素的乘积
            // 因为索引为 '0' 的元素左侧没有元素， 所以 answer[0] = 1
            answer[0] = 1;
            for (int i = 1; i < length; i++)
            {
                answer[i] = nums[i - 1] * answer[i - 1];
            }

            // R 为右侧所有元素的乘积
            // 刚开始右边没有元素，所以 R = 1
            int R = 1;
            for (int i = length - 1; i >= 0; i--)
            {
                // 对于索引 i，左边的乘积为 answer[i]，右边的乘积为 R
                answer[i] = answer[i] * R;
                // R 需要包含右边所有的乘积，所以计算下一个结果时需要将当前值乘到 R 上
                R *= nums[i];
            }
            return answer;

       
        }

        public int[] ProductExceptSelf2(int[] nums)
        {
            int length = nums.Length;

            int[] answer = new int[length];
            //先左边
            answer[0] = 1;
            for(int i=1;i<length;i++)
            {
                answer[i] = nums[i - 1] * answer[i - 1];

            }
            int R = 1;
            //再右边
            for(int i=length-1;i>=0;i--)
            {
                answer[i] = answer[i] * R;
                R = R * nums[i];
            }
            return answer;

        }

        public int[] ProductExceptSelf3(int[] nums)
        {
            int length = nums.Length;
            int[] answer = new int[length];
            answer[0] = 1;
            int r = 1;
            for(int i=1;i<length;i++)
            {
                answer[i] = answer[i - 1] * nums[i-1];
            }
            for(int i=length-1;i>=0;i--)
            {
                answer[i] = r * answer[i];
                r = nums[i] * r;
            }
            return answer;
        }

        public int[] ProductExceptSelf4(int[] nums)
        {
            int length = nums.Length;
            int[] awert = new int[length];
            awert[0] = 1;
            int r = 1;
            for(int i=1;i<length;i++)
            {
                awert[i] = awert[i - 1] * nums[i - 1];
            }
            for(int i=length-1;i>=0;i--)
            {
                awert[i] = r * awert[i];
                r = r * nums[i];

            }
            return awert;
        
        }
    }
}
