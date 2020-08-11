using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    /// <summary>
    /// leecode第3题
    /// </summary>
    public class LengthOfLongestSubstring
    {
        /// <summary>
        /// 我的解答
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring1(string s)
        {
            char[] temps = s.ToCharArray();
            int max = 1;
            if (temps.Length == 0)
            {
                return 0;
            }

            int temp = 0;

            for (int i = 0; i < temps.Length; i++)
            {
                bool[] tempchar = new bool[127];

                for (int j = i; j < temps.Length; j++)
                {
                    if (tempchar[temps[j]])
                    {

                        if (temp > max)
                        {
                            max = temp;

                        }
                        temp = 0;
                        break;
                    }
                    else
                    {
                        tempchar[temps[j]] = true;
                        temp = temp + 1;
                        if (temp > max)
                        {
                            max = temp;

                        }
                    }
                }
                temp = 0;

            }


            return max;
        }

        /// <summary>
        /// 最慢最消耗内存
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring2(string s)
        {
            if (s == null || s == "") return 0;
            int count = 0, maxCount = count;
            int[] wordIndex = new int[128];
            for (int i = 0, start = 0; i < s.Length; i++)
            {
                if (wordIndex[s[i]] != 0 && wordIndex[s[i]] > start)
                {
                    count -= (wordIndex[s[i]] - start);
                    start = wordIndex[s[i]];
                }
                if (++count > maxCount) maxCount = count;
                wordIndex[s[i]] = i + 1;
            }


            return maxCount;
        }
        /// <summary>
        /// 最快内存消耗最小
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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
    }
}
