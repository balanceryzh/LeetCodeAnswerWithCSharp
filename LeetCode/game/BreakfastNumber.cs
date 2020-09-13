using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ConsoleTest.game
{
    public class BreakfastNumber
    {
        public static int BreakfastNumber2(int[] staple, int[] drinks, int x)
        {

            int count = 0;
            Array.Sort(staple);
            Array.Sort(drinks);
            List<int> temp = new List<int>();
            foreach (int i in staple)
            {
                if (i >= x)
                {
                    break;
                }
                else
                {

                    temp.Add(i);
                }
            }

            foreach (int i in drinks)
            {
                if (i >= x)
                {
                    break;
                }
                else
                {
                    int temps = x - i;

                    int tempCount = temp.Where(o => o <= temps).Count();
                    count = count + tempCount;
                    if (count == 1000000008)
                    {
                        return 1;
                    }
                }
            }

            return count;

        }


        public static int BreakfastNumber3(int[] staple, int[] drinks, int x)
        {

            Array.Sort(staple);
            Array.Sort(drinks);
            int ans = 0, mod = 1000000007, i = 0, j = drinks.Length - 1;
            while (i < staple.Length && j >= 0)
            {
                if (staple[i] + drinks[j] > x)
                {
                    j--;
                }
                else
                {
                    ans = (ans + j + 1) % mod;
                    i++;
                }
            }
            return ans;

        }
    }
}
