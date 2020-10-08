﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Dynamic_Programming
{
//    爬楼梯
//假设你正在爬楼梯。需要 n 阶你才能到达楼顶。

//每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？

//注意：给定 n 是一个正整数。

//示例 1：

//输入： 2
//输出： 2
//解释： 有两种方法可以爬到楼顶。
//1.  1 阶 + 1 阶
//2.  2 阶
//示例 2：

//输入： 3
//输出： 3
//解释： 有三种方法可以爬到楼顶。
//1.  1 阶 + 1 阶 + 1 阶
//2.  1 阶 + 2 阶
//3.  2 阶 + 1 阶



    public class climbStairs
    {
        #region list1
        public int ClimbStairs(int n)
        {
            if (n < 2)
            {
                return n;
            }

            int max0 = 1;
            int max1 = 1;
            for (int i = 2; i <= n; i++)
            {
                var current = max0 + max1;
                max0 = max1;
                max1 = current;
            }

            return max1;
        }
        #endregion
        //public int ClimbStairs2(int n)
        //{
           

        //}
    }
}
