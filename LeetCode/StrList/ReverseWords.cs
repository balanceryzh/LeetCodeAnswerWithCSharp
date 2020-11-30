using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.StrList
{
    //151. 翻转字符串里的单词
//    给定一个字符串，逐个翻转字符串中的每个单词。

 

//示例 1：

//输入: "the sky is blue"
//输出: "blue is sky the"
//示例 2：

//输入: "  hello world!  "
//输出: "world! hello"
//解释: 输入字符串可以在前面或者后面包含多余的空格，但是反转后的字符不能包括。
//示例 3：

//输入: "a good   example"
//输出: "example good a"
//解释: 如果两个单词间有多余的空格，将反转后单词间的空格减少到只含一个。
 

//说明：

//无空格字符构成一个单词。
//输入字符串可以在前面或者后面包含多余的空格，但是反转后的字符不能包括。
//如果两个单词间有多余的空格，将反转后单词间的空格减少到只含一个。

    public class ReverseWords
    {
        #region list
        public string ReverseWords2(string s)
        {
            string[] templist = s.Split(' ');
            Stack<string> list = new Stack<string>();
            for (int i = 0; i < templist.Length; i++)
            {
                list.Push(templist[i]);
            }
            StringBuilder outstring = new StringBuilder();
            for (int i = 0; i < templist.Length; i++)
            {
                string tempstring = list.Pop();
                if (!string.IsNullOrWhiteSpace(tempstring))
                {
                    outstring.Append(tempstring);
                    outstring.Append(" ");
                }
            }
            return outstring.ToString().TrimEnd();
        }




;
        #endregion
        public string ReverseWords51(string s)
        {
            string[] list = s.Split(" ");
            Stack<string> templist = new Stack<string>();

            if (list.Length <= 1)
            {
                return s;
            }
            for (int i = 0; i < list.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(list[i]))
                {
                    templist.Push(list[i]);
                }
            }

            StringBuilder sb = new StringBuilder();
            while (templist.Count > 0)
            {
                sb.Append(templist.Pop());
                sb.Append(" ");
            }

            return sb.ToString().TrimEnd();
        }



    }





}

