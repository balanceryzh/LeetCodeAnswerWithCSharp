using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
//    验证回文串
//给定一个字符串，验证它是否是回文串，只考虑字母和数字字符，可以忽略字母的大小写。

//说明：本题中，我们将空字符串定义为有效的回文串。
    public class IsPalindrome
    {
        #region list
        public bool IsPalindrome1(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            s = s.ToLower();
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                {
                    ++left;
                }
                while (left < right && !char.IsLetterOrDigit(s[right]))
                {
                    --right;
                }
                if (s[left] != s[right])
                {
                    return false;
                }
                ++left;
                --right;
            }
            return true;
        }

        public bool IsPalindrome2(string s)
        {
            bool outs = true;


            List<char> list = new List<char>();
            if (s.Length > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {


                    if (s[i] >= 48 && s[i] <= 57)
                    {
                        list.Add(s[i]);
                    }
                    if (s[i] >= 65 && s[i] <= 90)
                    {
                        list.Add(Char.ToUpper(s[i]));
                    }
                    if (s[i] >= 97 && s[i] <= 122)
                    {
                        list.Add(Char.ToUpper(s[i]));
                    }

                }
                if (list.Count < 1 && s.Length < 1)
                {
                    return false;
                }
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] != list[list.Count - j - 1])
                    {
                        return false;
                    }
                }

            }

            return outs;


        }




        private bool IsLetterOrNum(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        private char Lowercase(char c)
        {
            return c >= 'A' && c <= 'Z' ? (char)(c + 32) : c;
        }
        #endregion 


        //public bool IsPalindrome5(string s)
        //{

        //}
    }
}
