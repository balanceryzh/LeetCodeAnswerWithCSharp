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
        #region list
      
        #endregion
        public static bool validPalindrome3(String s)
        {
            int low = 0;int high = s.Length - 1;
            while(low<high)
            {
                if(s[low]!=s[high])
                {
                    bool t1 = true;bool t2= true;
                    for(int i=low,j=high-1;i<j;i++,j--)
                    {
                        if(s[i]!=s[j])
                        {
                            t1 = false;
                            break;
                        }
                        
                    }
                    for (int i = low+1, j = high; i < j; i++, j--)
                    {
                        if (s[i] != s[j])
                        {
                            t2 = false;
                            break;
                        }

                    }
                    return t1 || t2;

                }
                low++;
                high--;
            }
            return true;
        }
    }
}
