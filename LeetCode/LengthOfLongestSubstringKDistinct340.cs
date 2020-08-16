using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTest
{
//    340. 至多包含 K 个不同字符的最长子串
//给定一个字符串 s ，找出 至多 包含 k 个不同字符的最长子串 T。

//示例 1:

//输入: s = "eceba", k = 2
//输出: 3
//解释: 则 T 为 "ece"，所以长度为 3。
//示例 2:

//输入: s = "aa", k = 1
//输出: 2
//解释: 则 T 为 "aa"，所以长度为 2。
    public class LengthOfLongestSubstringKDistinct340
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            int n = s.Length;
            if (n < k) return n;

            // sliding window left and right pointers
            int left = 0;
            int right = 0;
            // hashmap character -> its rightmost position 
            // in the sliding window
            Dictionary<char, int> hashmap = new Dictionary<char, int>();

            int max_len = k;

            while (right < n)
            {
                // slidewindow contains less than 3 characters
                if (hashmap.Count < k + 1)
                {
                    if (hashmap.ContainsKey(s[right]))
                    {
                        hashmap[s[right]] = right++;
                    }
                    else
                    {
                        hashmap.Add(s[right], right++);
                    }
                }


                // slidewindow contains 3 characters
                if (hashmap.Count == k + 1)
                {
                    // delete the leftmost character
                    int del_idx = hashmap.Keys.Select(x => new { x, y = hashmap[x] }).OrderBy(x => x.y).First().y;
                    hashmap.Remove(s[del_idx]);
                    // move left pointer of the slidewindow
                    left = del_idx + 1;
                }

                max_len = Math.Max(max_len, right - left);
            }
            return max_len;

        }
    }
}
