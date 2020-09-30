using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Dynamic_Programming
{
    public class minPathSum
    {
        //        最小路径和
        //   给定一个包含非负整数的 m x n 网格，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。

        //说明：每次只能向下或者向右移动一步。

        //示例:

        //输入:
        //[

        // [1,3,1],
        //  [1,5,1],
        //  [4,2,1]
        //]
        //输出: 7
        //解释: 因为路径 1→3→1→1→1 的总和最小。



        #region list
        public static int MinPathSum(int[][] grid)
        {
            int rows = grid.Length;
            int columns = grid[0].Length;

            int[] dpOneRow = new int[columns];

            for (int i = 0; i < dpOneRow.Length; i++)
            {
                dpOneRow[i] = int.MaxValue;
            }
            dpOneRow[0] = 0;
            for (int i = 0; i < rows; i++)
            {
                // 更新本行0列的路径和， 上一行0列路径和+本行0元素值
                dpOneRow[0] = dpOneRow[0] + grid[i][0];

                for (int j = 1; j < columns; j++)
                {
                    dpOneRow[j] = Math.Min(dpOneRow[j], dpOneRow[j - 1]) + grid[i][j];
                }
            }

            return dpOneRow[dpOneRow.Length - 1];
        }
        #endregion

        public static int MinPathSum2(int[][] grid)
        {
            int row = grid.Length;
            int col = grid[0].Length;

            int[] outList = new int[col];

            for(int i=0;i<outList.Length;i++)
            {
                outList[i] = int.MaxValue;

            }
            outList[0] = 0;
            for(int i=0;i<row;i++)
            {
                outList[0] = outList[0] + grid[i][0];
                for(int j=1;j<col;j++)
                {

                    outList[j] = Math.Min(outList[j], outList[j - 1]) + grid[i][j];
                }

            }
            return outList[outList.Length-1];
        }

    }
}
