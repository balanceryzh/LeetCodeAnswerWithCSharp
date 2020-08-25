﻿using System;
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


        public static int LengthOfLongestSubstring3(string s)
        {
            int max = s.Length >= 1 ? 1 : 0;
            Queue<char> que = new Queue<char>();
            char c;
            char delStr;
            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];

                //重复
                if (que.Contains(c))
                {
                    do
                    {
                        delStr = que.Dequeue();
                    } while (delStr != c);
                }
                que.Enqueue(c);
                max = que.Count > max ? que.Count : max;
            }
            return max;
        }


        public static int LengthOfLongestSubstring5(string s)
        {
            int max = s.Length >= 1 ? 1 : 0;
            Queue<char> que = new Queue<char>();
            char c;
            char delStr;
            for(int i = 0; i < s.Length; i++)
            {
                c = s[i];

                if(que.Contains(c))
                {
                    do
                    {
                        delStr = que.Dequeue();
                    } while (delStr != c);
                }

                que.Enqueue(c);
                max = que.Count > max ? que.Count : max;
            }





            return max;
        }


        public static int LengthOfLongestSubstring6(string s)
        {
            int max = s.Length >= 1 ? 1 : 0;

            char c, delstr;
            Queue<char> quesue = new Queue<char>();
            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];
                if(quesue.Contains(c))
                {
                    do { delstr = quesue.Dequeue(); } while (delstr != c);
                }
                
                    quesue.Enqueue(s[i]);
                
                max = quesue.Count > max ? quesue.Count : max;
            }

            return max;

        }

        public static int LengthOfLongestSubstring7(string s)
        {
            int max = s.Length >= 1 ? 1 : 0;
            char c, delstr;
            Queue<char> list = new Queue<char>();
            for(int i=0;i<s.Length;i++)
            {
                c = s[i];
                if(list.Contains(c))
                {

                    do { delstr = list.Dequeue(); } while (delstr != c);
                }
                list.Enqueue(c);
                max = max < list.Count ? list.Count : max;
            }

            return max;

        }

        public static int LengthOfLongestSubstring8(string s)
        {
            int max = s.Length >= 1 ? 1 : 0;
            char c, delstr;
            Queue<char> queueList = new Queue<char>();
            for(int i=0;i<s.Length;i++)
            {
                c = s[i];
                if(queueList.Contains(c))
                {
                    do{ delstr = queueList.Dequeue(); }while (delstr!=c) ;
                }
                queueList.Enqueue(c);
                max = max < queueList.Count ? queueList.Count : max;
            }

            return max;


        }


        public static int LengthOfLongestSubstring9(string s)
        {
            int max = s.Length >= 0 ? 1 : 0;
            char c, delstr;
            Queue<char> list = new Queue<char>();
            for(int i=0;i<s.Length;i++)
            {
                c = s[i];
                if(list.Contains(c))
                {
                    
                    do {
                        delstr = list.Dequeue();
                    
                    } while (delstr != c);
                }
                list.Enqueue(c);
            }
            max = max < list.Count ? list.Count : max;

            return max;
        }
    }
}