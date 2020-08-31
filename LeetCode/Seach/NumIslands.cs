using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleTest.Seach
{

    //给你一个由 '1'（陆地）和 '0'（水）组成的的二维网格，请你计算网格中岛屿的数量。

//岛屿总是被水包围，并且每座岛屿只能由水平方向或竖直方向上相邻的陆地连接形成。

//此外，你可以假设该网格的四条边均被水包围。

 

//示例 1:

//输入:
//[
//['1','1','1','1','0'],
//['1','1','0','1','0'],
//['1','1','0','0','0'],
//['0','0','0','0','0']
//]
//输出: 1
//示例 2:

//输入:
//[
//['1','1','0','0','0'],
//['1','1','0','0','0'],
//['0','0','1','0','0'],
//['0','0','0','1','1']
//]
//输出: 3
//解释: 每座岛屿只能由水平和/或竖直方向上相邻的陆地连接而成。

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

        public int NumIslands3(char[][] grid)
        {
            if(grid.Length==0)
            {
                return 0;
            }
            int landnum = 0;
            for(int i=0;i<grid.Length;i++)
            {
                for(int j=0;j<grid[0].Length;j++)
                {
                    if(grid[i][j]!='0')
                    {
                        DFS3(i, j, grid);
                        landnum++;
                    }

                }
            }


            return landnum;

        }

        public void DFS3(int x, int y, char[][] grid)
        {
            grid[x][y] = '0';

            if(x+1<grid.Length&&grid[x+1][y]=='1')
            {
                DFS3(x + 1, y, grid);
            }
            if (x - 1 >=0 && grid[x - 1][y] == '1')
            {
                DFS3(x - 1, y, grid);
            }
            if (y+ 1 < grid[0].Length && grid[x][y+1] == '1')
            {
                DFS3(x, y+1, grid);
            }
            if (y - 1 >= 0 && grid[x][y-1] == '1')
            {
                DFS3(x, y-1, grid);
            }
        }
    }
}
