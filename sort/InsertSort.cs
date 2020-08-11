using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Sort
{
    public  class InsertSort
    {
            //插入排序
            public static int[] insertSort(int[] list)
            {
               
                for (int i=1;i<list.Length;i++)
                {
                    int temp = list[i];
                    for (int j=i;j>0;j--)
                    {
                        if(temp <= list[j-1])
                        {
                            list[j] = list[j-1];

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

        #region 测试
        public static int[] insertSort2(int[] list)
        {
            for(int i=1;i<list.Length;i++)
            {
                int temp = list[i];
                for (int j = i; j > 0;j--)
                {
                    if(temp>=list[j-1])
                    {
                        list[j] = list[j - 1];
                    }
                    else
                    {
                        list[j] = temp;
                        break;
                    }
                    if(j-1==0)
                    {
                        list[j-1] = temp;
                    }
                }
            }
            return list;
        }
        public static int[] insertSortTest(int[] list)
        {
           
        }
        #endregion
    }
}
