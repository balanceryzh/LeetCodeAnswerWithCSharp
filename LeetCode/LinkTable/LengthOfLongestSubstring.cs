using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleTest.LinkTable
{
    public class LengthOfLongestSubstring
    {
        //无重复字符的最长子串(重点)
        //        给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。

        //示例 1:

        //输入: "abcabcbb"
        //输出: 3 
        //解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
        //示例 2:

        //输入: "bbbbb"
        //输出: 1
        //解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
        //示例 3:

        //输入: "pwwkew"
        //输出: 3
        //解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
        //     请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
        #region

        public static int LengthOfLongestSubstring3(string s)
        {
            int max = s.Length >= 1 ? 1 : 0;
            //先进先出无重复队列
            Queue<char> que = new Queue<char>();
            char c;
            char delStr;

            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];

                //如果重复则去重
                if (que.Contains(c))
                {
                    //从头开始去除，直到找到重复项
                    do
                    {
                        delStr = que.Dequeue();
                    } while (delStr != c);
                }
                //压入队列
                que.Enqueue(c);
                //比较队列长度
                max = que.Count > max ? que.Count : max;
            }
            return max;
        }









        #endregion
        //public static int LengthOfLongestSubstring12(string s)
        //{
        
        //}

    }
}
