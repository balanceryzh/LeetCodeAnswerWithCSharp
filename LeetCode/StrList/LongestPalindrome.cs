﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleTest.Test
{

  
//  5. 最长回文子串
//给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

//示例 1：

//输入: "babad"
//输出: "bab"
//注意: "aba" 也是一个有效答案。
//示例 2：

//输入: "cbbd"
    public class LongestPalindrome
    {

        //public static string LongestPalindrome2(string s)
        //{
           
        //}



        #region list



        public string LongestPalindrome5(string s)
        {
            string outList = "";
            int n = s.Length;
            int longLength = s.Length * 2 - 1;

            for (int i = 0; i < longLength; i++)
            {
                double mid = i / 2.0;

                int p = (int)Math.Floor(mid);
                int q = (int)Math.Ceiling(mid);

                while (p >= 0 && q < n)
                {
                    if (s[p] != s[q])
                    {
                        break;
                    }

                    p--; q++;
                }
                int len = q - p - 1;

                if (len > outList.Length)
                {
                    outList = s.Substring(p + 1, len);
                }



            }




            return outList;
        }


        public string LongestPalindrome6(string s)
        {
            string longest = "";
            int n = s.Length;
            int longLength = n * 2 - 1;
            for(int i=0;i<longLength;i++)
            {
                double mid = i / 2.0;

                int p = (int)Math.Floor(mid);
                int q = (int)Math.Ceiling(mid);

                while(p>=0&&q<n)
                {
                    if(s[p]!=s[q])
                    {
                        break;
                    }
                    p--;q++;
                }
                int len = q - p - 1;


                if(len>longest.Length)
                {
                    longest = s.Substring(p+1,len);
                }

               
            }

            return longest;
        }
        //
        public static string LongestPalindrome7(string s)
        {
            string outstring = "";
            int len = s.Length;
            int length = len * 2 - 1;
            for(int i=0;i<=length;i++)
            {
                double mid = i / 2.0;
                int p = (int)Math.Floor(mid);
                int q = (int)Math.Ceiling(mid);
                while(p>=0&&q<len)
                {
                    if(s[p]!=s[q])
                    {
                        break;
                    }
                    p--;q++;
                }
                int outlen = q - p - 1;
                if(outlen> outstring.Length)
                {
                    outstring = s.Substring(p + 1, outlen);
                }
              

            }

            return outstring;
        }
        public static string LongestPalindrome8(string s)
        {
            int len = s.Length;
            int templen = len * 2 - 1;
            string outString = "";
            for(int i=0;i<= templen; i++)
            {
                double mid = i / 2.0;
                int p = (int)Math.Floor(mid);
                int q = (int)Math.Ceiling(mid);
                while(p>=0&&q<len)
                {
                    if(s[p]!=s[q])
                    {
                        break;
                    }
                    p--;q++;
                }
                int outlen = q - p - 1;
                if(outlen> outString.Length)
                {
                    outString = s.Substring(p+1, outlen);
                }
            }


            return outString;


        }

        public static string LongestPalindrome9(string s)
        {
            int len = s.Length;
            int length = len * 2 - 1;
            string outString = "";
            for(int i=0;i<=length;i++)
            {
                double mid = i / 2.0;
                int p = (int)Math.Floor(mid);
                int q = (int)Math.Ceiling(mid);
                while(p>=0&&q<len)
                {
                    if(s[p]!=s[q])
                    {
                        break;
                    }
                    p--;q++;
                }
                int outInt = q - p - 1;
                if(outInt>outString.Length)
                {
                    outString.Substring(p + 1, outInt);
                }

            }
            return outString;
        
        }
        #endregion
    }
}
