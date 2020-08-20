using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.StrList
{
    //验证回文字符串 Ⅱ(重点)

   public class ValidPalindrome
    {
        //给定一个非空字符串 s，最多删除一个字符。判断是否能成为回文字符串。

//        示例 1:

//输入: "aba"
//输出: True
//示例 2:

//输入: "abca"
//输出: True
//解释: 你可以删除c字符。

        public bool validPalindrome2(String s)
        {
            int low = 0, high = s.Length - 1;
            while (low < high)
            {
                char c1 = s[low], c2 = s[high];
                if (c1 == c2)
                {
                    low++;
                    high--;
                }
                else
                {
                    bool flag1 = true, flag2 = true;
                    for (int i = low, j = high - 1; i < j; i++, j--)
                    {
                        char c3 = s[i], c4 = s[j];
                        if (c3 != c4)
                        {
                            flag1 = false;
                            break;
                        }
                    }
                    for (int i = low + 1, j = high; i < j; i++, j--)
                    {
                        char c3 = s[i], c4 = s[j];
                        if (c3 != c4)
                        {
                            flag2 = false;
                            break;
                        }
                    }
                    return flag1 || flag2;
                }
            }
            return true;
        }

    }
}
