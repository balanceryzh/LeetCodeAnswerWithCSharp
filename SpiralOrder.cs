using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    public class SpiralOrder
    {
        public IList<int> SpiralOrder2(int[][] matrix)
        {
            List<int> outList = new List<int>();

            if(matrix.Length<1|| matrix[0].Length < 1)
            {
                return outList;
            }
            int left = 0;
            int right = matrix[0].Length-1;


            int top = 0;
            int bottom = matrix.Length-1;

            while(left<=right&&top<=bottom)
            {

                for(int col=left;col<=right;col++)
                {
                    outList.Add(matrix[top][col]);
                }
                for(int row=top+1;row<= bottom;row++)
                {
                    outList.Add(matrix[row][right]);
                }
                if(left<right&&top<bottom)
                {
                    for(int col=right-1;col>=left;col--)
                    {
                        outList.Add(matrix[bottom][col]);
                    }
                    for (int row = bottom - 1; row > top; row--)
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

        public IList<int> SpiralOrder3(int[][] matrix)
        {

            List<int> outList = new List<int>();
            if (matrix == null || matrix.Length < 1|| matrix[0].Length < 1)
            {
                return outList;
            }
            int top = 0;
            int bottem = matrix.Length-1;
            int left = 0;
            int right = matrix[0].Length - 1;
            while(top<=bottem&&left<=right)
            {
                for(int col= left; col<=right;col++)
                {
                    outList.Add(matrix[top][col]);
                }
                for(int row=top+1;row<=bottem;row++)
                {
                    outList.Add(matrix[row][right]); ;
                }
                if(top<bottem&&left<right)
                {
                    for (int col = right-1; col >= left; col--)
                    {
                        outList.Add(matrix[bottem][col]);
                    }
                    for(int row=bottem-1;row>top;row--)
                    {
                        outList.Add(matrix[row][left]); ;
                    }
                }

                top++;
                bottem--;
                left++;
                right--;
            }

            return outList;

        }
    }
}
