using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.StrList
{
//    字符串相加(重点1)
//给定两个字符串形式的非负整数 num1 和num2 ，计算它们的和。

 

//提示：

//num1 和num2 的长度都小于 5100
//num1 和num2 都只包含数字 0-9
//num1 和num2 都不包含任何前导零
//你不能使用任何內建 BigInteger 库， 也不能直接将输入的字符串转换为整数形式




    public class AddStrings
    {
        #region list
        //
        public static string AddStrings2(string num1, string num2)
        {
            int len1 = num1.Length - 1;
            int len2 = num2.Length - 1;
            int ad = 0;
            StringBuilder str = new StringBuilder();

            while (len1 >= 0 || len2 >= 0 || ad != 0)
            {
                int x = len1 >= 0 ? num1[len1] - '0' : 0;

                int y = len2 >= 0 ? num2[len2] - '0' : 0;

                int tmp = x + y + ad;

                string s = (tmp % 10).ToString();

                str.Append(s);

                ad = tmp / 10;

                len1--;
                len2--;
            }

            string res = str.ToString();
            char[] chararr = res.ToCharArray();
            Array.Reverse(chararr);
            return new string(chararr);
        }

        public static string AddStrings3(string num1,string num2)
        {
            int i = num1.Length - 1;
            int j = num2.Length - 1;
            int a = 0;
            StringBuilder sb = new StringBuilder();
            while(i>=0||j>=0||a>0)
            {
                int x = i >= 0 ? num1[i] - '0' : 0;
                int y = j >= 0 ? num2[j] - '0' : 0;

                int temp = x + y + a;

                string s = (temp % 10).ToString();
                sb.Append(s);
                a = temp / 10;
                i--;
                j--;

            }
            char[] templsit = sb.ToString().ToCharArray();
            Array.Reverse(templsit);
            return new string(templsit);
        }

        public static string AddStrings4(string num1, string num2)
        {
            int i = num1.Length - 1;
            int j = num2.Length - 1;
            int a = 0;
            Stack<string> sb = new Stack<string>();
            while(i>=0||j>=0||a>0)
            {
                int x = i >= 0 ? num1[i] - '0' : 0;
                int y = j >= 0 ? num2[j] - '0' : 0;

                int temp = x + y + a;
                string outString = (temp % 10).ToString();
                sb.Push(outString);
                a = temp / 10;
                i--;
                j--;

            }
            StringBuilder sb1 = new StringBuilder();
            while(sb.Count>0)
            {
                sb1.Append(sb.Pop());
            }
            return sb1.ToString();

        }
        #endregion

        //public static string AddStrings5(string num1, string num2)
    }
}
