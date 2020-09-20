using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.game
{
    public class MaxProductPath
    {
		//int[][] grid;
		//long[][] pos;

		//long[][] ne;

		//int row, col;

		//long result = -1;

		//int mod = 1000000007;
		//public int maxProductPath(int[][] grid)
		//{

		//	this.grid = grid;
		//	row = grid.length;
		//	col = grid[0].length;

		//	pos = new long[row][col];

		//	ne = new long[row][col];

		//	DFS(0, 0, 1);

		//	return (int)(result % mod);

		//}


		//public void DFS(int r, int c, long res)
		//{

		//	if (r >= row || c >= col)
		//		return;
		//	res = res * grid[r][c];
		//	if (res < pos[r][c] && res > ne[r][c])
		//		return;
		//	pos[r][c] = Math.max(pos[r][c], res);
		//	ne[r][c] = Math.min(ne[r][c], res);

		//	DFS(r + 1, c, res);
		//	DFS(r, c + 1, res);
		//	if (r == row - 1 && c == col - 1)
		//		result = Math.max(result, res);



		//}
	}
}
