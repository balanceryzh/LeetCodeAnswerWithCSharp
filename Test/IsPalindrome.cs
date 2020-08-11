using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Test
{
    public class IsPalindrome
    {
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
    }
}
