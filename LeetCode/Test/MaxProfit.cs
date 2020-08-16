using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    public class MaxProfit
    {
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
    }
}
