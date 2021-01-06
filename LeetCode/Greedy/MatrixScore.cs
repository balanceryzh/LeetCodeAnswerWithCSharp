using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Greedy
{
    //861. 翻转矩阵后的得分
    public class MatrixScore
    {
        //861. Score After Flipping Matrix
        //We have a two dimensional matrix A where each value is 0 or 1.
        //A move consists of choosing any row or column, and toggling each value in that row or column: changing all 0s to 1s, and all 1s to 0s.
        //After making any number of moves, every row of this matrix is interpreted as a binary number, and the score of the matrix is the sum of these numbers.
        //Return the highest possible score.
        //有一个二维矩阵 A 其中每个元素的值为 0 或 1 。

        //移动是指选择任一行或列，并转换该行或列中的每一个值：将所有 0 都更改为 1，将所有 1 都更改为 0。

        //在做出任意次数的移动后，将该矩阵的每一行都按照二进制数来解释，矩阵的得分就是这些数字的总和。

        //返回尽可能高的分数。
        //示例：
        //输入：[[0,0,1,1],[1,0,1,0],[1,1,0,0]]
        //输出：39
        //解释：
        //转换为[[1, 1, 1, 1],[1,0,0,1],[1,1,1,1]]
        //0b1111 + 0b1001 + 0b1111 = 15 + 9 + 15 = 39



        public int matrixScore(int[][] A)
        {
            int m = A.Length, n = A[0].Length;

            int ret = m * (1 << (n - 1));


            for (int j = 1; j < n; j++)
            {
                int nOnes = 0;
                for (int i = 0; i < m; i++)
                {
                    if (A[i][0] == 1)
                    {
                        nOnes += A[i][j];
                    }
                    else
                    {
                        nOnes += (1 - A[i][j]); // 如果这一行进行了行反转，则该元素的实际取值为 1 - A[i][j]
                    }
                }
                int k = Math.Max(nOnes, m - nOnes);
                ret += k * (1 << (n - j - 1));
            }
            return ret;
        }

     

    }
}
