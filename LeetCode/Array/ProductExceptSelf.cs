using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Text;

namespace ConsoleTest.Test
{
    public class ProductExceptSelf
    {
        //除自身以外数组的乘积(重点)
        //左右乘积列表
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

     

        public int[] ProductExceptSelf5(int[] nums)
        {
            int length = nums.Length;
            int[] awsure = new int[length];
            awsure[0] = 1;
            int r = 1;
            for (int i=1;i<length;i++)
            {
                awsure[i] =awsure[i-1]*nums[i-1];
            }
            for(int i = length-1; i >= 0; i--)
            {
                awsure[i] = r * awsure[i];
                r = r * nums[i];
            }
                return awsure;
            
        
        
        }



        public int[] ProductExceptSelf6(int[] nums)
        {
            int length = nums.Length;
            int[] outList = new int[length];
            int r = 1;
            outList[0] = 1;
            for(int i=1;i<length;i++)
            {
                outList[i] = outList[i - 1] * nums[i - 1];
            }
            for(int i=length-1;i>=0;i--)
            {
                outList[i] = r * outList[i];
                r = r * nums[i];
            }

            return outList;


        }

        public static int[] ProductExceptSelf7(int[] nums)
        {
            int len = nums.Length;
            int[] outList = new int[len];
            int r = 1;
            outList[0] = 1;
            for(int i=1;i<len;i++)
            {
                outList[i] = outList[i - 1] * nums[i - 1];
            }
            for(int i=len-1;i>=0;i--)
            {
                outList[i] = r * outList[i];
                r = r * nums[i];
            }
            return outList;
        }

        public static int[] ProductExceptSelf8(int[] nums)
        {
            if(nums.Length==0)
            {
                return nums;
            }
            int len = nums.Length;
            int[] tempi = new int[len];
            tempi[0] = 1;
            int r = 1;
            for(int i=1;i<len;i++)
            {
                tempi[i] = tempi[i - 1] * nums[i - 1];
            }
            for(int i=len-1;i>=0;i--)
            {
                tempi[i] = tempi[i] * r;
                r = r * nums[i];

            }

            return tempi;



        }
    }
}
