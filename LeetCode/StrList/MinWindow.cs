using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.StrList
{
    public class MinWindow
    {
        public string MinWindow2(string s, string t)
        {
            Dictionary<char, int> need = new Dictionary<char, int>();
            Dictionary<char, int> window = new Dictionary<char, int>();
            foreach (var item in t)
            {
                if (!need.ContainsKey(item))
                {
                    need.Add(item, 1);
                }
                else
                {
                    need[item]++;
                }
            }
            int left = 0;
            int right = 0;
            int valide = 0;

            int startindex = 0;
            int len = int.MaxValue;
            while (right < s.Length)
            {
                char c = s[right];
                right++;
                if (need.ContainsKey(c))
                {
                    if (!window.ContainsKey(c))
                    {
                        window.Add(c, 1);
                    }
                    else
                    {
                        window[c]++;
                    }
                    if (window[c] == need[c])
                    {
                        valide++;
                    }
                }
                while (valide == need.Count)
                {

                    if (right - left < len)
                    {
                        len = right - left;
                        startindex = left;
                    }
                    char d = s[left];
                    left++;
                    if (need.ContainsKey(d))
                    {
                        if (window[d] == need[d])
                        {
                            valide--;
                        }
                        window[d]--;
                    }
                }
            }
            return len == int.MaxValue ? "" : s.Substring(startindex, len);
        }


    }
}
