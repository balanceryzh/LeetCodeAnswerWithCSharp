using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
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

        public string MinRemoveToMakeValid3(string s) 
        {
            StringBuilder sb = new StringBuilder();
            int open = 0;
            int close = 0;
            for(int i=0;i<s.Length;i++)
            {
                if(s[i]=='(')
                {
                    open++;
                    close++;
                }
                if(s[i]==')')
                {
                    if (close <= 0) continue;
                    close--;
                }
                sb.Append(s[i]);
            }
            StringBuilder sb2 = new StringBuilder();
            int outString = open - close;
            for(int i=0;i<sb.Length;i++)
            {
                if(sb[i]=='(')
                {
                    if (outString <= 0) continue;
                    outString--;
                }

                sb2.Append(sb[i]);
            }

            return sb2.ToString();
        }

        public string MinRemoveToMakeValid4(string s)
        {
            StringBuilder sb = new StringBuilder();
            int open = 0;
            int close = 0;
            for(int i=0;i<s.Length;i++)
            {
                if(s[i]=='(')
                {
                    open = open + 1;
                    close = close + 1;
                }
                else if(s[i]==')')
                {
                    if (close <= 0) continue;
                    close = close - 1;
                }

                sb.Append(s[i]);
            }
            StringBuilder sb2 = new StringBuilder();
            int temp = open - close;

            for(int i=0;i<sb.Length;i++)
            {
                if(sb[i]=='(')
                {
                    if (temp <= 0) continue;
                    temp = temp - 1;
                }

                sb2.Append(sb[i]);
            }

            return sb2.ToString();


        }



    }
}
