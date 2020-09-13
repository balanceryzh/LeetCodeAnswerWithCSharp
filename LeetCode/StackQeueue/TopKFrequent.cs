using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.StackQeueue
{
    //前K个高频单词
    public class TopKFrequent
    {
        #region list
        //还可用linq 内存消耗多一些
        public IList<string> TopKFrequent2(string[] words, int k)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var word in words)
            {
                dic[word] = dic.ContainsKey(word) ? dic[word] + 1 : 1;
            }

            var res = dic.OrderByDescending(s => s.Value).ThenBy(s => s.Key).Take(k).ToList();

            List<string> list = new List<string>();

            for (int i = 0; i < k; i++)
            {
                list.Add(res[i].Key);
            }


            return list;
        }
        public IList<string> TopKFrequent3(string[] words, int k)
        {
            Dictionary<string, int> templist = new Dictionary<string, int>();
            foreach(string word in words)
            {

                templist[word] = templist.ContainsKey(word) ? templist[word] + 1 : 1;
            }
            var list = templist.OrderByDescending(o => o.Value).ThenBy(o => o.Key).Take(k).ToList();

            List<string> outlist = new List<string>();

            for(int i=0;i<k;i++)
            {
                outlist.Add(list[i].Key);
            }

            return outlist;

        }

        public IList<string> TopKFrequent4(string[] words, int k)
        {
            Dictionary<string, int> templist = new Dictionary<string, int>();
            foreach(string word in words)
            {
                templist[word] = templist.ContainsKey(word) ? templist[word] + 1:1;
            }
            var list = templist.OrderByDescending(o => o.Value).ThenBy(o => o.Key).Take(k).ToList();
            List<string> outList = new List<string>();

            for(int i=0;i<k;i++)
            {
                outList.Add(list[i].Key);
            }
            return outList;

        }
        public IList<string> TopKFrequent5(string[] words, int k)
        {
            Dictionary<string, int> tempList = new Dictionary<string, int>();
            foreach (string word in words)
            {
                tempList[word] = tempList.ContainsKey(word) ? tempList[word] + 1 : 1;
            }

            var list = tempList.OrderByDescending(o => o.Value).ThenBy(o => o.Key).Take(k).ToList();
            List<string> outlist = new List<string>();
            for (int i = 0; i < k; i++)
            {
                outlist.Add(list[i].Key);
            }
            return outlist;


        }
        public IList<string> TopKFrequent6(string[] words, int k)
        {
            Dictionary<string, int> templist = new Dictionary<string, int>();
            foreach (string word in words)
            {
                templist[word] = templist.ContainsKey(word) ? templist[word] + 1 : 1;

            }
            var list = templist.OrderByDescending(o => o.Value).ThenBy(o => o.Key).Take(k).ToList();
            List<string> outList = new List<string>();
            for (int i = 0; i < k; i++)
            {
                outList.Add(list[i].Key);
            }
            return outList;

        }
        #endregion
     

        public IList<string> TopKFrequent8(string[] words, int k)
        {
            List<string> outtemp = new List<string>();
            Dictionary<string, int> list = new Dictionary<string, int>();
            for(int i=0;i<words.Length;i++)
            {
                if(list.ContainsKey(words[i]))
                {
                    list[words[i]]++;
                }
                else
                {
                    list.Add(words[i],1);
                }
            }

            var outlist = list.OrderByDescending(o => o.Value).ThenBy(o => o.Key).Take(k).ToList();

            foreach(var node in outlist)
            {
                outtemp.Add(node.Key);
            }
            return outtemp;

        }


    }
}
