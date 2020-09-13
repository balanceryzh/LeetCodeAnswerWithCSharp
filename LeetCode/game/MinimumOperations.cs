using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.game
{
    public class MinimumOperations
    {
        public int minimumOperations(String leaves)
        {
			int length = leaves.Length;
			int left = 0;
			int right = length - 1;
			while (left < length && leaves[left] == 'r')
			{
				++left;
			}
			while (right >= 0 && leaves[right] == 'r')
			{
				--right;
			}
			if (left == right)
			{
				return 0;
			}
			if (right < left)
			{
				return 1;
			}
			int sum = 0;
			if (left == 0)
			{
				++sum;
				++left;
			}
			if (right == (length - 1))
			{
				++sum;
				--right;
			}
			int num = 0;
			int min = 1;
			int first = 0;
			int second = 0;
			for (int i = left; i <= right; i++)
			{
				second = first;
				if (leaves[i] == 'r')
				{
					++second;
				}
				else
				{
					--second;
					++sum;
				}
				if (second >= num)
				{
					num = second;
				}
				else
				{
					if ((second - num) < min)
					{
						min = second - num;
					}
				}
				first = second;
			}
			sum += min;
			return sum >= 0 ? sum : 0;

		}
    }
}
