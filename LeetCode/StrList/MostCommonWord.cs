using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.StrList
{
    //最常见的单词(重点)
    public class MostCommonWord
    {
        //        给定一个段落(paragraph) 和一个禁用单词列表(banned)。返回出现次数最多，同时不在禁用列表中的单词。

        //题目保证至少有一个词不在禁用列表中，而且答案唯一。

        //禁用列表中的单词用小写字母表示，不含标点符号。段落中的单词不区分大小写。答案都是小写字母。



        //示例：

        //输入: 
        //paragraph = "Bob hit a ball, the hit BALL flew far after it was hit."
        //banned = ["hit"]
        //        输出: "ball"
        //解释: 
        //"hit" 出现了3次，但它是一个禁用的单词。
        //"ball" 出现了2次(同时没有其他单词出现2次)，所以它是段落里出现次数最多的，且不在禁用列表中的单词。 
        //注意，所有这些单词在段落里不区分大小写，标点符号需要忽略（即使是紧挨着单词也忽略， 比如 "ball,"）， 
        //"hit"不是最终的答案，虽然它出现次数更多，但它在禁用单词列表中。


        //提示：

        //1 <= 段落长度 <= 1000
        //0 <= 禁用单词个数 <= 100
        //1 <= 禁用单词长度 <= 10
        //答案是唯一的, 且都是小写字母(即使在 paragraph 里是大写的，即使是一些特定的名词，答案都是小写的。)
        //paragraph 只包含字母、空格和下列标点符号!?',;.
        //不存在没有连字符或者带有连字符的单词。
        //单词里只包含字母，不会出现省略号或者其他标点符号。

        #region list
        public static string MostCommonWord2(string paragraph, string[] banned)
        {
            string newpara = paragraph.Replace(".", " ").Replace(",", " ").Replace("?", " ").Replace(";", " ").Replace("'", "").Replace("!"," ");
            string[] arr = newpara.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for(int i=0;i<arr.Length;i++)
            {
                string xiaoxie = arr[i].ToLower();
                if(banned.Contains(xiaoxie)==false)
                {
                    if(dic.ContainsKey(xiaoxie))
                    {
                        dic[xiaoxie]++;
                    }
                    else
                    {
                        dic.Add(xiaoxie, 1);

                    }
                       
                }
                else
                {
                    continue;
                }
            }

            return dic.Where(p => p.Value == dic.Values.Max()).Select(p => p.Key).FirstOrDefault();
        }
        public string MostCommonWord3(string paragraph, string[] banned)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            paragraph = paragraph.ToLower();

            int start = -1;

            int end = 0;
            while (end < paragraph.Length)
            {
                if (paragraph[end] < 'a' || paragraph[end] > 'z')
                {
                    if (start < 0)
                    {
                        end++;
                        continue;
                    }
                    string str = paragraph.Substring(start, end - start);

                    if (map.ContainsKey(str))
                    {
                        map[str]++;
                    }
                    else
                    {
                        map[str] = 1;
                    }

                    end++;
                    start = -1;
                }
                else
                {
                    if (start < 0)
                    {
                        start = end;
                    }
                    end++;
                }
            }


            if (start < paragraph.Length && start >= 0)
            {
                string str = paragraph.Substring(start, paragraph.Length - start);
                if (map.ContainsKey(str))
                {
                    map[str]++;
                }
                else
                {
                    map[str] = 1;
                }
            }



            foreach (var item in banned)
            {
                map[item] = -1;
            }


            int max = 0;
            string maxStr = "";
            foreach (var item in map)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    maxStr = item.Key;
                }
            }
            return maxStr;
        }


        public string MostCommonWord4(string paragraph, string[] banned)
        {
            int start = -1;
            int end = 0;
            Dictionary<string, int> list = new Dictionary<string, int>();
            paragraph = paragraph.ToLower();
            while (end<paragraph.Length)
            {
                if (paragraph[end] < 'a' || paragraph[end] > 'z')
                {
                    if(start<0)
                    {
                        end++;
                        continue;
                    }
                    else
                    {
                        string str = paragraph.Substring(start, end - start);
                        if(list.ContainsKey(str))
                        {
                            list[str]++;
                        }
                        else
                        {
                            list.Add(str, 1);
                        }
                        end++;
                        start = -1;
                    }
                }
                else
                {
                    if(start<0)
                    {
                        start = end;
                    }
                    end++;
                }
            }
            if(start>=0&&start< paragraph.Length)
            {
                string str = paragraph.Substring(start, paragraph.Length - start);
                if(list.ContainsKey(str))
                {
                    list[str]++;
                }
                else
                {
                    list.Add(str,1);
                }
            }
            foreach(var item in banned)
            {
                list[item] = -1;

            }

            int max = 0;string outstring = "";

            foreach(var item in list)
            {
                if(max<item.Value)
                {
                    max = item.Value;
                    outstring = item.Key;
                }

            }

            return outstring;

        }
        #endregion


        //public string MostCommonWord5(string par, string[] ban)
        //{
           
        //}
    }
}
