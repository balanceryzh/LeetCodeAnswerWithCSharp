using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    public class SpiralOrder
    {
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
        public IList<int> SpiralOrder2(int[][] matrix)
        {
            List<int> list = new List<int>();
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return list;
            }
            int top = 0;
            int bottom = matrix.Length - 1;
            int left = 0;
            int right= matrix[0].Length - 1;
            while(top<=bottom&&left<=right)
            {

                for(int col=left;col<=right;col++)
                {
                    list.Add(matrix[top][col]);
                }
                for (int row = top+1; row <= bottom; row++)
                {
                    list.Add(matrix[row][right]);
                }
                if(left < right && top < bottom)
                {
                    for(int col=right-1;col>left;col--)
                    {
                        list.Add(matrix[bottom][col]);
                    }
                    for (int row = bottom ; row >top; row--)
                    {
                        list.Add(matrix[row][left]);
                    }


                }


                top++;
                bottom--;
                left++;
                right--;
            }



            return list;
        }


        public IList<int> SpiralOrder3(int[][] matrix)
        {
            List<int> list = new List<int>();
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return list;
            }
            int top = 0;
            int bottom = matrix.Length - 1;
            int left = 0;
            int right = matrix[0].Length - 1;
            while(top<= bottom&& left<= right)
            {

                for(int col= left; col<= right; col++)
                {
                    list.Add(matrix[top][col]);
                }
                for (int row = top+1; row <= bottom; row++)
                {
                    list.Add(matrix[row][right]);
                }
                if(left<right &&top<bottom)
                {
                    for(int col=right-1;col>left;col--)
                    {
                        list.Add(matrix[bottom][col]);
                    }

                    for (int row = bottom - 1; row > top; row--)
                    {
                        list.Add(matrix[row][left]);
                    }


                }


                top++;
                bottom--;
                left++;
                right--;
            }


            return list;
        }

        public IList<int> SpiralOrder4(int[][] matrix)
        {
            List<int> listInt = new List<int>();
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return list;
            }
            int left = 0;
            int right = matrix[0].Length - 1;
            int top = 0;
            int bottom = matrix.Length - 1;
            while(left<=right&&top<=bottom)
            {
                for(int col=left;col<=right;col++)
                {
                    listInt.Add(matrix[top][col]);
                }
                for (int row = top-1; row <= bottom; row++)
                {
                    listInt.Add(matrix[row][right]);
                }
                if(left<right&&top<bottom)
                {
                    for(int col=right-1;col>left;col--)
                    {
                        listInt.Add(matrix[bottom][col]);
                    }
                    for(int row = bottom - 1; row > top; row--)
                    {
                        listInt.Add(matrix[row][left]);
                    }

                }


                left++;
                right--;
                top++;
                bottom--;
            }


            return listInt;


        }

        #endregion
    }
}
