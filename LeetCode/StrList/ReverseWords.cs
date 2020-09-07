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


        public string ReverseWords3(string s)
        {
            string[] slist = s.Split(' ');
            Stack<string> temp = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            for(int i=0;i<slist.Length;i++)
            {
                if(!string.IsNullOrWhiteSpace(slist[i]))
                {
                    temp.Push(slist[i]);

                }

            }
            while(temp.Count>0)
            {
                sb.Append(temp.Pop());
                sb.Append(" ");
            }

            return sb.ToString().TrimEnd();

;
        }

        public string ReverseWords4(string s)
        {
            string[] slist = s.Split(" ");
            Stack<string> list = new Stack<string>();
            for(int i=0;i<slist.Length;i++)
            {
                if (!string.IsNullOrWhiteSpace(slist[i]))
                    {
                    list.Push(slist[i]);
                }
            }
            StringBuilder sb = new StringBuilder();
            while(list.Count>0)
            {
                sb.Append(list.Pop());
                sb.Append(" ");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
