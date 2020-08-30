using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Array
{
    public class MinRemoveToMakeValid
    {
        public string MinRemoveToMakeValid2(string s)
        {
            StringBuilder sb = new StringBuilder();
            int openCount = 0;
            int balanceCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    openCount++;
                    balanceCount++;
                }
                else if (s[i] == ')')
                {
                    if (balanceCount == 0) continue;
                    balanceCount--;
                }
                sb.Append(s[i]);
            }
            string str = sb.ToString();
            sb = new StringBuilder();
            int BalancedOpenCount = openCount - balanceCount;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    if (BalancedOpenCount <= 0) continue;
                    BalancedOpenCount--;
                }
                sb.Append(str[i]);
            }
            return sb.ToString();
        }


    }
}
