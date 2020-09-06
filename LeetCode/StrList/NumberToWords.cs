using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.StrList
{

//    整数转换英文表示(重点)
//将非负整数转换为其对应的英文表示。可以保证给定输入小于 231 - 1 。

//示例 1:

//输入: 123
//输出: "One Hundred Twenty Three"
//示例 2:

//输入: 12345
//输出: "Twelve Thousand Three Hundred Forty Five"
//示例 3:

//输入: 1234567
//输出: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
//示例 4:

//输入: 1234567891
//输出: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"


    public class NumberToWords2
    {
        //字典 + 拆分
        public Dictionary<int, string> numDic = new Dictionary<int, string>()
{
    {0, "Zero"},
    {1, "One"},
    {2, "Two"},
    {3, "Three"},
    {4, "Four"},
    {5, "Five"},
    {6, "Six"},
    {7, "Seven"},
    {8, "Eight"},
    {9, "Nine"},
    {10, "Ten"},
    {11, "Eleven"},
    {12, "Twelve"},
    {13, "Thirteen"},
    {14, "Fourteen"},
    {15, "Fifteen"},
    {16, "Sixteen"},
    {17, "Seventeen"},
    {18, "Eighteen"},
    {19, "Nineteen"}
};

        public Dictionary<int, string> tyDic = new Dictionary<int, string>()
{
    {2, "Twenty"},
    {3, "Thirty"},
    {4, "Forty"},
    {5, "Fifty"},
    {6, "Sixty"},
    {7, "Seventy"},
    {8, "Eighty"},
    {9, "Ninety"}
};

      
        

        public string NumberToWords3(int num)
        {
            if (num < 20) return numDic[num];
            StringBuilder str = new StringBuilder();
            if(num<100)
            {
                int x = num / 10;
                int y = num % 10;
                str.Append(tyDic[x]);
                if (y > 0) str.Append(' ' + numDic[y]);
            }
            else if(num<1000)
            {
                int x = num / 100;
                int y = num % 100;
                str.Append(numDic[x]);
                str.Append(" Hundred");
                if (y > 0) str.Append(' ' + NumberToWords3(y));
            }
            else if(num<1000000)
            {
                int x = num / 1000;
                int y = num % 1000;
                str.Append(NumberToWords3(x));
                str.Append(" Thousand");
                if (y > 0) str.Append(' ' + NumberToWords3(y));
            }
            else if(num< 1000000000)
            {
                int x = num / 1000000;
                int y = num % 1000000;
                str.Append(NumberToWords3(x));
                str.Append(" Million");
                if (y > 0) str.Append(' ' + NumberToWords3(y));
            }
            else
            {
                int x = num / 1000000000;
                int y = num % 1000000000;
                str.Append(NumberToWords3(x));
                str.Append(" Billion");
                if (y > 0) str.Append(' ' + NumberToWords3(y));
            }
            return str.ToString();

        }

        public Dictionary<int, string> nums = new Dictionary<int, string>()
{
    {0, "Zero"},
    {1, "One"},
    {2, "Two"},
    {3, "Three"},
    {4, "Four"},
    {5, "Five"},
    {6, "Six"},
    {7, "Seven"},
    {8, "Eight"},
    {9, "Nine"},
    {10, "Ten"},
    {11, "Eleven"},
    {12, "Twelve"},
    {13, "Thirteen"},
    {14, "Fourteen"},
    {15, "Fifteen"},
    {16, "Sixteen"},
    {17, "Seventeen"},
    {18, "Eighteen"},
    {19, "Nineteen"}
};

        public Dictionary<int, string> tys = new Dictionary<int, string>()
{
    {2, "Twenty"},
    {3, "Thirty"},
    {4, "Forty"},
    {5, "Fifty"},
    {6, "Sixty"},
    {7, "Seventy"},
    {8, "Eighty"},
    {9, "Ninety"}
};
        public string NumberToWords4(int num)
        {
            StringBuilder sb = new StringBuilder();
            if (num < 20) return nums[num];
            if(num<100)
            {
                int x = num / 10;
                int y = num % 10;
                sb.Append(tys[x]);
                if (y > 0) sb.Append(" " + nums[y]);

            }
            else if(num<1000)
            {
                int x = num / 100;
                int y = num % 100;
                sb.Append(nums[x]);
                sb.Append(" Hundred");
                if (y > 0) sb.Append(" " + NumberToWords4(y));
            }
            else if (num < 1000000)
            {
                int x = num / 1000;
                int y = num % 1000;
                sb.Append(NumberToWords4(x));
                sb.Append(" Thousand");
                if (y > 0) sb.Append(" " + NumberToWords4(y));
            }
            else if (num < 1000000000)
            {
                int x = num / 1000000;
                int y = num % 1000000;
                sb.Append(NumberToWords4(x));
                sb.Append(" Million");
                if (y > 0) sb.Append(" " + NumberToWords4(y));
            }
            else
            {
                int x = num / 1000000000;
                int y = num % 1000000000;
                sb.Append(NumberToWords4(x));
                sb.Append(" Billion");
                if (y > 0) sb.Append(" " + NumberToWords4(y));
            }
            return sb.ToString();
        }




        public string NumberToWords5(int num)
        {
            if (num < 20) return nums[num];
            StringBuilder sb = new StringBuilder();
            if(num<100)
            {
                int x = num / 10;
                int y = num % 10;
                sb.Append(tys[x]);
                if (y > 0) { sb.Append(" "+nums[y]); }
            }
            else if(num<1000)
            {
                int x = num / 100;
                int y = num % 100;
                sb.Append(nums[x]);
                sb.Append(" Hundred");
                if (y > 0) { sb.Append(" " + NumberToWords5(y)); }
            }
            else if(num<1000000)
            {
                int x = num / 1000;
                int y = num % 1000;
                sb.Append(NumberToWords5(x));
                sb.Append(" Thousand");
                if (y > 0) { sb.Append(" " + NumberToWords5(y)); }
            }
            else if(num<1000000000)
            {
                int x = num / 1000000;
                int y = num % 1000000;
                sb.Append(NumberToWords5(x));
                sb.Append(" Million");
                if (y > 0) { sb.Append(" " + NumberToWords5(y)); }

            }
            else
            {
                int x = num / 1000000000;
                int y = num % 1000000000;
                sb.Append(NumberToWords5(x));
                sb.Append(" Billion");
                if (y > 0) { sb.Append(" " + NumberToWords5(y)); }
            }
            return sb.ToString();
        }
        public string NumberToWords(int num)
        {
            if (num < 20) return nums[num];
            StringBuilder sb = new StringBuilder();
            if(num<100)
            {
                int x = num / 10;
                int y = num % 10;
                sb.Append(tys[x]);
                if (y > 0) { sb.Append(" "+nums[y]); }
                
            }
            else if(num<1000)
            {
                int x = num / 100;
                int y = num % 100;
                sb.Append(nums[x]);
                sb.Append(" Hundred");
                if (y > 0) { sb.Append(" " + NumberToWords(y)); }

            }
            else if(num<1000000)
            {
                int x = num / 1000;
                int y = num % 1000;
                sb.Append(NumberToWords(x));
                sb.Append(" Thousand");
                if (y > 0) { sb.Append(" " + NumberToWords(y)); }
            }
            else if(num<1000000000)
            {
                int x = num / 1000000;
                int y = num % 1000000;
                sb.Append(NumberToWords(x));
                sb.Append(" Million");
                if (y > 0) { sb.Append(" " + NumberToWords(y)); }
            }
            else
            {
                int x = num / 1000000000;
                int y = num % 1000000000;
                sb.Append(NumberToWords(x));
                sb.Append(" Billion");
                if (y > 0) { sb.Append(" " + NumberToWords(y)); }
            }
            return sb.ToString();
        }



    }
}
