using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public class Reverse
    {
        public static int Reverse1(int x)
        {
            long temp = 0;
            while(x!=0)
            {

                temp = temp * 10 + x % 10;
             
                x = x / 10;
            }
            if (temp > int.MaxValue || temp < int.MinValue)
            {
                return 0;
            }
            return (int)temp;
        }

        public int Reverse2(int x)
        {
            int result = 0;
            int y = 0;
            while (x != 0)
            {
                try
                {
                    y = x % 10;
                    x = x / 10;
                    result = checked((result * 10) + y);
                }
                catch (System.OverflowException)
                {
                    result = 0;
                }
            }
            return result;
        }
    }
}
