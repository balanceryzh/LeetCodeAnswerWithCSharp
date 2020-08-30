using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Array
{
   public class Trap
    {
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



    }
}
