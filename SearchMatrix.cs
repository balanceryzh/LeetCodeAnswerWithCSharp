using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    public class SearchMatrix
    {
        public bool SearchMatrix1(int[][] matrix, int target)
        {
            if(matrix.Length<1)
            {
                return false;
            }
            for (int i = 0; i < matrix.Length;i++)
            {
                if (matrix[i].Length < 1)
                {
                    return false;
                }
                if (target>=matrix[i][0]&&target<= matrix[i][matrix[i].Length-1])
                {
                    for(int j=0;j< matrix[i].Length;j++)
                    {
                        if(target == matrix[i][j])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool SearchMatrix2(int[][] matrix, int target)
        {

            bool result = false;
            foreach (var item in matrix)
            {
                if (item.Contains(target))
                {
                    result = true;
                    break;
                };

            }
            return result;
        }
    }
}
