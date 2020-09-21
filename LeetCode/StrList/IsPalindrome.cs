using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
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


        public bool IsPalindrome3(string s)
        {
            int a = 0, b = s.Length - 1;
            while (a < b)
            {
                if (!IsLetterOrNum(s[a])) { a++; continue; }
                if (!IsLetterOrNum(s[b])) { b--; continue; }
                if (Lowercase(s[a]) != Lowercase(s[b])) return false;
                a++;b--;
            }
            return true;
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
