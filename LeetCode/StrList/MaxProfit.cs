﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{

    //    买卖股票的最佳时机
    //给定一个数组，它的第 i 个元素是一支给定股票第 i 天的价格。

    //如果你最多只允许完成一笔交易（即买入和卖出一支股票一次），设计一个算法来计算你所能获取的最大利润。

    //注意：你不能在买入股票前卖出股票。



    //示例 1:

    //输入: [7,1,5,3,6,4]
    //    输出: 5
    //解释: 在第 2 天（股票价格 = 1）的时候买入，在第 5 天（股票价格 = 6）的时候卖出，最大利润 = 6-1 = 5 。
    //     注意利润不能是 7-1 = 6, 因为卖出价格需要大于买入价格；同时，你不能在买入前卖出股票。
    //示例 2:

    //输入: [7,6,4,3,1]
    //    输出: 0
    //解释: 在这种情况下, 没有交易完成, 所以最大利润为 0。


    public class MaxProfit
    {

        #region list
        public int MaxProfit1(int[] prices)
        {

            if (prices.Length < 1)
            {
                return 0;
            }
            int max = 0;
            int minStart = int.MaxValue;
            ///循环用每一个去减后面的数字找最大数,如果后面的数大于前面的数则忽略
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minStart)
                {



                    for (int j = i + 1; j < prices.Length; j++)
                    {
                        if (prices[j] - prices[i] > max)
                        {
                            max = prices[j] - prices[i];

                        }
                    }
                    if (prices[i] < minStart)
                    {
                        minStart = prices[i];
                    }
                }
            }
            return max;
        }


        public int MaxProfit2(int[] prices)
        {
            if (prices.Length == 0) return 0;
            var buy = prices[0];
            var max = 0;
            for (var i = 1; i < prices.Length; i++)
            {
                //一直选择最便宜的为最佳买入点
                if (prices[i] < buy)
                {
                    buy = prices[i];
                }
                else
                {
                    //选择最大卖出收益
                    max = prices[i] - buy > max ? prices[i] - buy : max;
                }
            }

            return max;
        }
        #endregion

        //public int MaxProfit3(int[] prices)
        //{
           
        //}
    }
}
