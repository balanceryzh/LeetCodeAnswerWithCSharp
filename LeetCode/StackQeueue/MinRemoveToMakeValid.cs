using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.StackQeueue
{
    public class MinRemoveToMakeValid
    {

//        给你一个由 '('、')' 和小写字母组成的字符串 s。

//你需要从字符串中删除最少数目的 '(' 或者 ')' （可以删除任意位置的括号)，使得剩下的「括号字符串」有效。

//请返回任意一个合法字符串。

//有效「括号字符串」应当符合以下 任意一条 要求：

//空字符串或只包含小写字母的字符串
//可以被写作 AB（A 连接 B）的字符串，其中 A 和 B 都是有效「括号字符串」
//可以被写作(A) 的字符串，其中 A 是一个有效的「括号字符串」
 

//示例 1：

//输入：s = "lee(t(c)o)de)"
//输出："lee(t(c)o)de"
//解释："lee(t(co)de)" , "lee(t(c)ode)" 也是一个可行答案。
//示例 2：

//输入：s = "a)b(c)d"
//输出："ab(c)d"
//示例 3：

//输入：s = "))(("
//输出：""
//解释：空字符串也是有效的
//示例 4：

//输入：s = "(a(b(c)d)"
//输出："a(b(c)d)"
 

//提示：

//1 <= s.length <= 10^5
//s[i] 可能是 '('、')' 或英文小写字母



        public String minRemoveToMakeValid(String s)
        {

            // Parse 1: Remove all invalid ")"
            StringBuilder sb = new StringBuilder();
            int openSeen = 0;
            int balance = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(')
                {
                    openSeen++;
                    balance++;
                }
                if (c == ')')
                {
                    if (balance == 0) continue;
                    balance--;
                }
                sb.Append(c);
            }

            // Parse 2: Remove the rightmost "("
            StringBuilder result = new StringBuilder();
            int openToKeep = openSeen - balance;
            for (int i = 0; i < sb.Length; i++)
            {
                char c = sb[i];
                if (c == '(')
                {
                    openToKeep--;
                    if (openToKeep < 0) continue;
                }
                result.Append(c);
            }

            return result.ToString();
        }

        public string MinRemoveToMakeValid2(string s)
        {
            StringBuilder sb = new StringBuilder();
            int openCount = 0;
            int balanceCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    openCount++;
                    balanceCount++;
                }
                else if (s[i] == ')')
                {
                    if (balanceCount == 0) continue;
                    balanceCount--;
                }
                sb.Append(s[i]);
            }
            string str = sb.ToString();
            sb = new StringBuilder();
            int BalancedOpenCount = openCount - balanceCount;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    if (BalancedOpenCount <= 0) continue;
                    BalancedOpenCount--;
                }
                sb.Append(str[i]);
            }
            return sb.ToString();
        }

        public string MinRemoveToMakeValid3(string s)
        {
            StringBuilder sb = new StringBuilder();
            int open = 0;
            int close = 0;
            for(int i=0;i<s.Length;i++)
            {
                if(s[i]=='(')
                {
                    open++;
                    close++;
                }
                else if(s[i]==')')
                {
                    if (close == 0) continue;
                    else close--;
                }

                sb.Append(s[i]);

            }
            int outs = open - close;
            StringBuilder sb2 = new StringBuilder();
            for(int i=0;i<sb.Length;i++)
            {
                if(sb[i]=='(')
                {
                    if (outs == 0) continue;
                       else outs--;
                }

                sb2.Append(sb[i]);
            }

            return sb2.ToString();

        }
    }
}
