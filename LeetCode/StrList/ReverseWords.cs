using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.StrList
{
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
    }
}
