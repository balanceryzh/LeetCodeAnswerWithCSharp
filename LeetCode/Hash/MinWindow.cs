using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ConsoleTest.Hash
{

    //    最小覆盖子串
    //给你一个字符串 S、一个字符串 T 。请你设计一种算法，可以在 O(n) 的时间复杂度内，从字符串 S 里面找出：包含 T 所有字符的最小子串。



    //示例：

    //输入：S = "ADOBECODEBANC", T = "ABC"
    //输出："BANC"


    //提示：

    //如果 S 中不存这样的子串，则返回空字符串 ""。
    //如果 S 中存在这样的子串，我们保证它是唯一的答案。

    public class minWindow
    {
        #region list
        public string MinWindow(string s, string t)
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
            int end = 0;
            int valide = 0;

            int startindex = 0;
            int len = int.MaxValue;
            while (end < s.Length)
            {
                char c = s[end];
                end++;
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

                    if (end - left < len)
                    {
                        len = end - left;
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
        #endregion

        //public string MinWindow2(string s, string t)
        //{
           
        //}


    }

}