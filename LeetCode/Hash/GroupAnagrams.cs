﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Hash
{
    public class GroupAnagrams
    {

        //给定一个字符串数组，将字母异位词组合在一起。字母异位词指字母相同，但排列不同的字符串。

//        示例:

//输入: ["eat", "tea", "tan", "ate", "nat", "bat"]
//        输出:
//[
//  ["ate","eat","tea"],
//  ["nat","tan"],
//  ["bat"]
//]
//说明：

//所有输入均为小写字母。
//不考虑答案输出的顺序。


        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            Dictionary<long, int> s = new Dictionary<long, int>();
        
            IList<IList<string>> ret = new List<IList<string>>();
            int count = 0;

            for (int i = 0; i < strs.Length; i++)
            {
                long t = 1;

                for (int j = 0; j < strs[i].Length; j++)
                {
                    t =t* (long)((int)strs[i][j] + 100);
                }

                if (s.ContainsKey(t))
                {
                    ret[s[t]].Add(strs[i]);
                }
                else
                {
                    s.Add(t, count);
                    ret.Add(new List<string>() { strs[i] });
                    count++;
                }
            }
            return ret;
        }
        public IList<IList<string>> GroupAnagrams3(string[] strs)
        {
            Dictionary<long, int> list = new Dictionary<long, int>();

            List<IList<string>> outlist = new List<IList<string>>();
            int count = 0;

            for(int i=0;i<strs.Length;i++)
            {
                long t = 1;
                for(int j=0;j<strs[i].Length;j++)
                {
                    t = t * (long)((int)strs[i][j] + 100);
                }
                if(list.ContainsKey(t))
                {
                    outlist[list[t]].Add(strs[i]);
                }
                else
                {
                    list.Add(t, count);
                    count++;
                    outlist.Add(new List<string> { strs[i] });

                }

            }
            return outlist;

        }
   }
}