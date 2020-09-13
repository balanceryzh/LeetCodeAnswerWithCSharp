using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public class Trap
    {
        //        给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。



        //上面是由数组[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1] 表示的高度图，在这种情况下，可以接 6 个单位的雨水（蓝色部分表示雨水）。 感谢 Marcos 贡献此图。

        //示例:

        //输入: [0,1,0,2,1,0,1,3,2,1,2,1]
        //        输出: 6
        #region Test
        public int Trap2(int[] height)
        {
            if (height == null || height.Length <= 0)
            {
                return 0;
            }

            var monotonicStack = new Stack<int>();
            int result = 0;
            for (int i = 0; i < height.Length; ++i)
            {
                while (monotonicStack.Count != 0 && height[monotonicStack.Peek()] < height[i])
                {
                    //获取凹槽的高度
                    int notch = monotonicStack.Pop();
                    //如果出栈后，栈为空，说明在边界水会流出去，所以直接跳出即可
                    if (monotonicStack.Count == 0) break;

                    //槽左到右的距离
                    int distance = i - monotonicStack.Peek() - 1;
                    //短板效应，最小的高度，注意要减去凹槽的高
                    int minHeight = Math.Min(height[i], height[monotonicStack.Peek()]) - height[notch];
                    //结果相乘累加
                    result += distance * minHeight;
                }
                monotonicStack.Push(i);
            }

            return result;
        }



        #endregion

        public int Trap5(int[] height)
        {
            if(height.Length==0)
            {
                return 0;
            }
            Stack<int> list = new Stack<int>();
            int trapcount = 0;
            for(int i=0;i<height.Length;i++)
            {
                while(list.Count>0&&height[i]>height[list.Peek()])
                {
                    int temp = list.Pop();
                    if (list.Count == 0) break;
                    int width = i - list.Peek() - 1;
                    int heights = Math.Min(height[i], height[list.Peek()]) - height[temp];
                    trapcount = trapcount + width * heights;
                }
                list.Push(i);
            }
            return trapcount;
        }

    }
}
