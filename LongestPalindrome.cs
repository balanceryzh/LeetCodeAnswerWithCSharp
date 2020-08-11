﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleTest.Test
{
    public class LongestPalindrome
    {
        public string LongestPalindrome2(string s)
        {
            string result = "";
            int n = s.Length;
            int end = 2 * n - 1;

            for (int i = 0; i < end; i++)
            {

                double mid = i / 2.0;
                int p = (int)(Math.Floor(mid));

                int q = (int)(Math.Ceiling(mid));

                //每个字母两边扩散比较，扩散到边界
                while (p >= 0 && q < n)
                {
                    if (s[p] != s[q]) break;
                    p--; q++;
                }

                //判断是否最大回文串
                int len = q - p - 1;
                if (len > result.Length)
                    result = s.Substring(p + 1, len);
            }
            return result;
        }

        #region
        public string LongestPalindrome3(string s)
        {
            string result = "";
            int longs= s.Length * 2 - 1;
            int n = s.Length - 1;
            for (int i = 0; i <= longs; i++)
            {
                double mid = longs / 2.0;
                int p = (int)Math.Floor(mid);
                int q = (int)Math.Ceiling(mid);
                int len = 0;
                while(p>=0&&q<n)
                {
                    if(s[p]!=s[q])
                    {
                        break;
                    }
                
                    p--;q++;
                }
                len = q - p-1;
                if (len>result.Length)
                {
                    result.Substring(p+1,len);
                }



            }
            return result;
        }


        public string LongestPalindrome4(string s)
        {
            string outstring = "";
            int n = s.Length;
            int longs = s.Length * 2 - 1;
            for(int i=0;i<longs;i++)
            {
                double mid = i / 0.2;
                int p = (int)Math.Floor(mid);
                int q = (int)Math.Ceiling(mid);
                while(p>=0&&q<n)
                {
                    if(s[p]!=s[q])
                    {
                        break;
                    }
                    else
                    {
                        p--;q++;
                    }
                }
                int len = q - p-1;
                if(len>outstring.Length)
                {
                    outstring = s.Substring(p+1, len);
                }

            }
            return outstring;

        }

        #endregion
    }
}
