using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    public class SpiralOrder
    {
        //螺旋矩阵
        //方法二：按层模拟
        //可以将矩阵看成若干层，首先输出最外层的元素，其次输出次外层的元素，直到输出最内层的元素。
        //时间复杂度：O(mn)O(mn)，其中 mm 和 nn 分别是输入矩阵的行数和列数。矩阵中的每个元素都要被访问一次。
        //空间复杂度：O(1)O(1)。除了输出数组以外，空间复杂度是常数。

        public IList<int> SpiralOrder1(int[][] matrix)
        {
            List<int> order = new List<int>();
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return order;
            }
            int rows = matrix.Length, columns = matrix[0].Length;
            int left = 0, right = columns - 1, top = 0, bottom = rows - 1;
            while (left <= right && top <= bottom)
            {
                for (int column = left; column <= right; column++)
                {
                    order.Add(matrix[top][column]);
                }
                for (int row = top + 1; row <= bottom; row++)
                {
                    order.Add(matrix[row][right]);
                }

                if (left < right && top < bottom)
                {
                    for (int column = right - 1; column > left; column--)
                    {
                        order.Add(matrix[bottom][column]);
                    }
                    for (int row = bottom; row > top; row--)
                    {
                        order.Add(matrix[row][left]);
                    }
                }






                left++;
                right--;
                top++;
                bottom--;


            }




            return order;
        }
        #region 测试


        public static IList<int> SpiralOrder5(int[][] matrix)
        {
            List<int> outList = new List<int>();
            if (matrix == null || matrix.Length == 0||matrix[0].Length==0)
            {
                return outList;
            }
            int left = 0; int right = matrix[0].Length - 1;
            int top = 0;int bottom = matrix.Length - 1;

            while(left<=right && top<=bottom)
            {
                for(int col=left;col<=right;col++)
                {
                    outList.Add(matrix[top][col]);
                }
                for (int row = top+1; row <= bottom; row++)
                {
                    outList.Add(matrix[row][right]);
                }
                if(left < right && top < bottom)
                {
                    for (int col = right-1; col > left; col--)
                    {
                        outList.Add(matrix[bottom][col]);
                    }
                    for (int row = bottom; row > top; row--)
                    {
                        outList.Add(matrix[row][left]);
                    }

                }

                left++;
                right--;
                top++;
                bottom--;
            }


            return outList;
        }
        #endregion
    }
}
