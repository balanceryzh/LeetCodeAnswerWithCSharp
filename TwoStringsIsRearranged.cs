using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    public class TwoStringsIsRearranged
    {
        public static bool TwoStringsIsRearranged1(string text1,string text2)
        {


            int[] list1 = new int[127];
            int[] list2 = new int[127];
            int temp1 = 0;
            int temp2 = 0;
            char[] temptext1 = text1.ToCharArray();
            while(temp1< temptext1.Length)
            {
                list1[temptext1[temp1]] = list1[temptext1[temp1]] + 1;
                temp1 = temp1 + 1;
            }


            char[] temptext2 = text2.ToCharArray();
            while (temp2 < temptext2.Length)
            {
                list2[temptext2[temp2]] = list2[temptext2[temp2]] + 1;
                temp2 = temp2 + 1;
            }


            if (list1.SequenceEqual(list2))
            {
                return true;
            }

           return false;

        }

    }
}
