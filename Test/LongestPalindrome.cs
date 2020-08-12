using System;
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
        #endregion
    }
}
