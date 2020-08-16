using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTest
{
//给定一个字符串 s ，找出 至多包含两个不同字符的最长子串 t ，并返回该子串的长度。

//示例 1:

//输入: "eceba"
//输出: 3
//解释: t 是 "ece"，长度为3。
//示例 2:

//输入: "ccaabbb"
//输出: 5
//解释: t 是 "aabbb"，长度为5。


    public class LengthOfLongestSubstringTwoDistinct159
    {
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            int n = s.Length;
            if (n < 3) return n;

            // sliding window left and right pointers
            int left = 0;
            int right = 0;
            // hashmap character -> its rightmost position 
            // in the sliding window
            Dictionary<char, int> hashmap = new Dictionary<char, int>();

            int max_len = 2;

            while (right < n)
            {
                // slidewindow contains less than 3 characters
                if (hashmap.Count < 3)
                {
                    if(hashmap.ContainsKey(s[right]))
                    {
                        hashmap[s[right]] = right++;
                    }
                    else
                    {
                        hashmap.Add(s[right], right++);
                    }
                }
                   

                // slidewindow contains 3 characters
                if (hashmap.Count == 3)
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
