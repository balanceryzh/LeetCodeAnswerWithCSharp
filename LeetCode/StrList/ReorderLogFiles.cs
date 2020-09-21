using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.StrList
{
    //    重新排列日志文件
    //   你有一个日志数组 logs。每条日志都是以空格分隔的字串。

    //对于每条日志，其第一个字为字母与数字混合的 标识符 ，除标识符之外的所有字为这一条日志的 内容 。

    //除标识符之外，所有字均由小写字母组成的，称为 字母日志
    //除标识符之外，所有字均由数字组成的，称为 数字日志
    //题目所用数据保证每个日志在其标识符后面至少有一个字。

    //请按下述规则将日志重新排序：

    //所有 字母日志 都排在 数字日志 之前。
    //字母日志 在内容不同时，忽略标识符后，按内容字母顺序排序；在内容相同时，按标识符排序；
    //数字日志 应该按原来的顺序排列。
    //返回日志的最终顺序。



    //示例 ：

    //输入：["a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo"]
    //    输出：["g1 act car","a8 act zoo","ab1 off key dog","a1 9 2 3 1","zo4 4 7"]


    public class ReorderLogFiles
    {
        #region list
        public string[] reorderLogFiles(string[] logs)
        {
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            for (int i = 0; i < logs.Length; i++)
            {
                string[] temp = logs[i].Split(" ");
                if (char.IsDigit(temp[1][0]))
                {
                    list2.Add(logs[i]);
                }
                else
                {
                    list1.Add(logs[i]);
                }

            }

            list1.Sort((a,b)=> {
                String[] s1 = a.Split(" ", 2);
                String[] s2 = b.Split(" ", 2);
                int cmp = s1[1].CompareTo(s2[1]);
                if (cmp != 0)
                {
                    return cmp;
                }
                return s1[0].CompareTo(s2[0]);


            });
            List<string> outlist = new List<string>();
            foreach(var node in list1)
            {
                outlist.Add(node);
            }
            foreach (var node in list2)
            {
                outlist.Add(node);
            }
            return outlist.ToArray();
        }
        #endregion

        //public static string[] reorderLogFiles2(string[] logs)
        //{
            
        //}

    }
}


