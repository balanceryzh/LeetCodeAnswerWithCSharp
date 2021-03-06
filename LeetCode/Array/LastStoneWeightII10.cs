﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ConsoleTest.Test
{

    //最后一块石头的重量 II(重点1)
    /// <summary>
    /// 有一堆石头，每块石头的重量都是正整数。

    //每一回合，从中选出任意两块石头，然后将它们一起粉碎。假设石头的重量分别为 x 和 y，且 x <= y。那么粉碎的可能结果如下：

    //如果 x == y，那么两块石头都会被完全粉碎；
    //如果 x != y，那么重量为 x 的石头将会完全粉碎，而重量为 y 的石头新重量为 y-x。
    //最后，最多只会剩下一块石头。返回此石头最小的可能重量。如果没有石头剩下，就返回 0。



    //示例：

    //输入：[2,7,4,1,8,1]
    //    输出：1
    //解释：
    //组合 2 和 4，得到 2，所以数组转化为[2, 7, 1, 8, 1]，
    //组合 7 和 8，得到 1，所以数组转化为[2, 1, 1, 1]，
    //组合 2 和 1，得到 1，所以数组转化为[1, 1, 1]，
    //组合 1 和 1，得到 0，所以数组转化为[1]，这就是最优值。


    //提示：

    //1 <= stones.length <= 30
    //1 <= stones[i] <= 1000


    /// </summary>
    public class LastStoneWeightII10
    {
        //背包问题
        public static int LastStoneWeightII1(int[] stones)
        {  /* 由于石头拿走还能放回去，因此可以简单地把所有石头看作两堆
         * 假设总重量为 sum, 则问题转化为背包问题：如何使两堆石头总重量接近 sum / 2
         */
            int len = stones.Length;
            /* 获取石头总重量 */
            int sum = 0;
            foreach (int i in stones)
            {
                sum += i;
            }
            /* 定义 dp[i] 重量上限为 i 时背包所能装载的最大石头重量 */
            int maxCapacity = sum / 2;
            int[] dp = new int[maxCapacity + 1];


            for (int i = 0; i < len; i++)
            {
                int curStone = stones[i];
                for (int j = maxCapacity; j >= curStone; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - curStone] + curStone);
                }
            }

            //总重减两个背包能装最大重量的石头
            return sum - 2 * dp[maxCapacity];



        }



        public static int LastStoneWeightII2(int[] stones)
        {

            int sum = 0;
            foreach (int i in stones)
            {
                sum = sum + i;
            }

            int bagmax = sum / 2;
            int[] bg = new int[bagmax + 1];
            for (int i = 0; i < stones.Length; i++)
            {
                int stone = stones[i];
                for (int j = bagmax; j >= stone; j--)
                {
                    bg[j] = Math.Max(bg[j], bg[j - stone] + stone);
                }
            }

            return sum - 2 * bg[bagmax];


        }

        public static int LastStoneWeightII3(int[] stones)
        {

            int sum = 0;
            foreach (int i in stones)
            {
                sum = sum + i;
            }

            int bagMax = sum / 2;

            int[] bg = new int[bagMax + 1];

            for (int i = 0; i < stones.Length; i++)
            {
                int stone = stones[i];
                for (int j = bagMax; j >= stone; j--)
                {
                    bg[j] = Math.Max(bg[j], bg[j - stone] + stone);
                }


            }
            return sum - 2 * bg[bagMax];

        }

        public static int LastStoneWeightII4(int[] stones)
        {
            int sum = 0;
            foreach (int i in stones)
            {
                sum = sum + i;
            }
            int bagMax = sum / 2;
            int[] bg = new int[bagMax + 1];
            for (int i = 0; i < stones.Length; i++)
            {
                int stone = stones[i];
                for (int j = bagMax; j >= stone; j--)
                {
                    bg[j] = Math.Max(bg[j], bg[j - stone] + stone);
                }
            }
            return sum - 2 * bg[bagMax];

        }
        public static int LastStoneWeightII5(int[] stones)
        {
            int sum = 0;
            foreach (int i in stones)
            {
                sum = sum + i;
            }
            int maxbag = sum / 2;
            int[] bgmax = new int[maxbag + 1];
            for (int i = 0; i < stones.Length; i++)
            {
                int stone = stones[i];
                for (int j = maxbag; j >= stone; j--)
                {
                    bgmax[j] = Math.Max(bgmax[j], bgmax[j - stone] + stone);
                }
            }

            return sum - 2 * bgmax[maxbag];

        }

        public static int LastStoneWeightII6(int[] stones)
        {
            int sum = 0;
            foreach (int i in stones)
            {
                sum = sum + i;
            }
            int maxbag = sum / 2;
            int[] bgmax = new int[maxbag + 1];
            for (int i = 0; i < stones.Length; i++)
            {
                int stone = stones[i];
                for (int j = maxbag; j >= stone; j--)
                {
                    bgmax[j] = Math.Max(bgmax[j], bgmax[j - stone] + stone);
                }
            }


            return sum - 2 * bgmax[maxbag];
        }

        public static int LastStoneWeightII7(int[] stones)
        {
            int sum = 0;
            foreach (int i in stones)
            {
                sum = sum + i;
            }
            int maxbg = sum / 2;
            int[] bgs = new int[maxbg + 1];
            for (int i = 0; i < stones.Length; i++)
            {
                int stone = stones[i];
                for (int j = maxbg; j >= stone; j--)
                {
                    bgs[j] = Math.Max(bgs[j], bgs[j - stone] + stone);
                }



            }

            return sum - 2 * bgs[maxbg];










        }


        public static int LastStoneWeightII8(int[] stones)
        {
            int sum = 0;
            foreach (int i in stones)
            {
                sum = sum + i;
            }

            int maxbag = sum / 2;
            int[] bgmax = new int[maxbag];
            for (int i = 0; i < stones.Length; i++)
            {
                int stone = stones[i];
                for (int j = maxbag; j >= stone; j--)
                {
                    bgmax[j] = Math.Max(bgmax[j], bgmax[j - stone] + stone);
                }
            }

            return sum - 2 * bgmax[maxbag];




        }

        public static int LastStoneWeightII9(int[] stones)
        {
            int sum = 0;
            foreach (int temp in stones)
            {
                sum = sum + temp;
            }

            int bigbag = sum / 2;
            int[] bgs = new int[bigbag + 1];

            for (int i = 0; i < stones.Length; i++)
            {
                int stone = stones[i];
                for (int j = bigbag; j >= stone; j--)
                {
                    bgs[j] = Math.Max(bgs[j], bgs[j - stone] + stone);
                }

            }
            return sum - 2 * bgs[bigbag];

        }
    }
}
