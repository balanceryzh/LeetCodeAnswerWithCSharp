using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Seach
{
    public class NumIslands
    {
        public int NumIslands2(char[][] grid)
        {
            if (grid.Length == 0)
                return 0;
            int nums = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] != '0')
                    {
                        DFS(i, j, grid);
                        nums++;
                    }
                }
            }
            return nums;
        }
        public void DFS(int x, int y, char[][] grid)
        {
            grid[x][y] = '0';   //可以认为走过的土地都陷进了海里
            if (x + 1 < grid.Length && grid[x + 1][y] == '1') //向下
                DFS(x + 1, y, grid);
            if (y + 1 < grid[0].Length && grid[x][y + 1] == '1') //向右
                DFS(x, y + 1, grid);
            if (x - 1 >= 0 && grid[x - 1][y] == '1') //向上
                DFS(x - 1, y, grid);
            if (y - 1 >= 0 && grid[x][y - 1] == '1')//向左
                DFS(x, y - 1, grid);
        }


    }
}
