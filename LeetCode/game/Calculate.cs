using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.game
{
   public class Calculate
    {
        public static int Calculate2(string s)
        {
            int x = 1;
            int y = 0;
          
            if(s.Length==0)
            {
                return x+y;
            }
            Queue<char> list = new Queue<char>();
            for(int i=0;i<s.Length;i++)
            {
                list.Enqueue(s[i]);
            }
            while(list.Count>0)
            {
                char temp = list.Dequeue();
                if(temp == 'A')
                {
                    x =  2 * x + y;
                }
                else if(temp == 'B')
                {
                    y = 2 * y + x;
                }
            }
            return x + y;
        }
    }
}
