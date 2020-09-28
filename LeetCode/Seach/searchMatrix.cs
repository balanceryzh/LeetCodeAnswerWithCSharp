using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Seach
{
    //Write an efficient algorithm that searches for a value in an m x n matrix
    //    编写一个高效的算法来搜索 m x n 矩阵 matrix 中的一个目标值 target。该矩阵具有以下特性：

    //每行的元素从左到右升序排列。
    //每列的元素从上到下升序排列。
    //示例:

    //现有矩阵 matrix 如下：

    //[
    //  [1,   4,  7, 11, 15],
    //  [2,   5,  8, 12, 19],
    //  [3,   6,  9, 16, 22],
    //  [10, 13, 14, 17, 24],
    //  [18, 21, 23, 26, 30]
    //]
    //给定 target = 5，返回 true。

    //给定 target = 20，返回 false。


    public class searchMatrix
    {
        #region list

        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0) return false;

            int column = matrix.GetLength(1);
            int columning = 0;
            int row = matrix.GetLength(0) - 1;

            while (columning < column && row >= 0)
            {
                int cur = matrix[row, columning];
                if (cur == target) return true;
                else if (cur > target) row--;
                else columning++;
            }

            return false;
        }
        #endregion
        //public bool SearchMatrix2(int[,] matrix, int target)
        //{




        //}
    }
}
