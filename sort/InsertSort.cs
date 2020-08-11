using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.sort
{
   public  class InsertSort
    {
        public static int[] insertSort1(int[] list)
        {
			for (int i = 1; i < list.Length; i++)
			{
				int temp = list[i];
				for (int j = i; j > 0; j--)
				{
					if (list[j-1] >= temp)
					{
						list[j] = list[j - 1];
					}
					else
					{
						list[j] = temp;
						break;
					}
					if (j - 1 == 0)
					{
						list[j - 1] = temp;
					}
				}
			}
			return list;

		}
	}
}
