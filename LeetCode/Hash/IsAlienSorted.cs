using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Hash
{

//    验证外星语词典
//某种外星语也使用英文小写字母，但可能顺序 order 不同。字母表的顺序（order）是一些小写字母的排列。

//给定一组用外星语书写的单词 words，以及其字母表的顺序 order，只有当给定的单词在这种外星语中按字典序排列时，返回 true；否则，返回 false。

 

//示例 1：

//输入：words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
//输出：true
//解释：在该语言的字母表中，'h' 位于 'l' 之前，所以单词序列是按字典序排列的。
//示例 2：

//输入：words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
//输出：false
//解释：在该语言的字母表中，'d' 位于 'l' 之后，那么 words[0] > words[1]，因此单词序列不是按字典序排列的。
//示例 3：

//输入：words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
//输出：false
//解释：当前三个字符 "app" 匹配时，第二个字符串相对短一些，然后根据词典编纂规则 "apple" > "app"，因为 'l' > '∅'，其中 '∅' 是空白字符，定义为比任何其他字符都小（

   public  class IsAlienSorted
    {
        #region list
        public bool isAlienSorted2(String[] words, String order)
        {
            int[] index = new int[26];

            for (int i = 0; i < order.Length; ++i)
                index[order[i] - 'a'] = i;

            for (int i = 0; i < words.Length - 1; ++i)
            {
                int temp = 0;
                String word1 = words[i];
                String word2 = words[i + 1];

                // Find the first difference word1[k] != word2[k].
                for (int k = 0; k < Math.Min(word1.Length, word2.Length); ++k)
                {
                    if (word1[k] != word2[k])
                    {
                        // If they compare badly, it's not sorted.
                        if (index[word1[k] - 'a'] > index[word2[k] - 'a'])
                            return false;
                        temp = 1;
                        break;
                    }
                }
                if (temp == 1)
                {
                    continue;
                }
                // If we didn't find a first difference, the
                // words are like ("app", "apple").
                if (word1.Length > word2.Length)
                    return false;
            }

            return true;
        }
        public static bool isAlienSorted3(String[] words, String order)
        {
            int[] index = new int[26];
            for(int i=0;i<order.Length;i++)
            {
                index[order[i] - 'a'] = i;
            }
            for(int i=0;i<words.Length-1;i++)
            {
     

            
                String word1 = words[i];
                String word2 = words[i + 1];


                for (int k = 0; k < Math.Min(word1.Length, word2.Length); k++)
                {
                    if (word1[k] != word2[k])
                    {
                        if (index[word1[k] - 'a'] > index[word2[k] - 'a'])
                        {
                            return false;
                        }
                        break;
                    }
                    if(k == Math.Min(word1.Length, word2.Length)-1)
                    {
                        if (word1.Length > word2.Length)
                            return false;
                    }
                }
           

            }
            return true;
        }

       
        public static bool isAlienSorted4(String[] words, String order)
        {
            int[] newlist = new int[26];

            for(int i=0;i<order.Length ;i++)
            {
                newlist[order[i] - 'a'] = i;
            }
            for(int j=0;j<words.Length-1;j++)
            {


                string word1 = words[j];
                string word2 = words[j + 1];
                for(int k=0;k<Math.Min(word1.Length,word2.Length);k++)
                {
                    if(word1[k]!=word2[k])
                    {
                        if(newlist[word1[k]-'a']> newlist[word2[k] - 'a'])
                        {
                            return false;
                        }
                        break;

                    }
                    else
                    {
                        if(k== Math.Min(word1.Length, word2.Length)-1&&word1.Length>word2.Length)
                        {
                            return false;
                        }

                    }


                }



            }


            return true;

        }
        #endregion

        //public static bool isAlienSorted5(String[] words, String order)
    }
}
