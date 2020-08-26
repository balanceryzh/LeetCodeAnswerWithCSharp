using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Text;

namespace ConsoleTest
{
    //有效的括号
//    给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。

//有效字符串需满足：

//左括号必须用相同类型的右括号闭合。
//左括号必须以正确的顺序闭合。
//注意空字符串可被认为是有效字符串。

//示例 1:

//输入: "()"
//输出: true
//示例 2:

//输入: "()[]{}"
//输出: true
//示例 3:

//输入: "(]"
//输出: false
//示例 4:

//输入: "([)]"
//输出: false
//示例 5:

//输入: "{[]}"
//输出: true


    public class IsValid
    {
        public static bool IsValid1(string s)
        {
            char[] list = s.ToCharArray();
            int temp1 = 0;
            int temp2 = 0;
            int temp3 = 0;
            int tempindex1 = -1;
            int tempindex2 = -1;
            int tempindex3 = -1;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == '{')
                {
                    temp1 = 1;
                    tempindex1 = i;
                }
                if (list[i] == '}')
                {
                    if (temp1 < 1)
                    {
                        return false;

                    }
                    else if (temp1 == 1 )
                    {
                        if (tempindex1 > tempindex2 && tempindex1 > tempindex3)
                        {
                            temp1 = 2;
                            tempindex1 = tempindex1-1;
                        }
                        else
                        {

                            return false;

                        }
                    }
                    else
                    {
                        if (temp2 == 1 || temp3 == 1)
                        {
                            return false;
                        }

                    }
                }

                if (list[i] == '[')
                {
                    temp2 = 1;
                    tempindex2 = i;
                }
                if (list[i] == ']')
                {
                    if (temp2 < 1)
                    {
                        return false;

                    }
                    else if(temp2==1)
                    {
                        if (tempindex2 > tempindex1 && tempindex2 > tempindex3)
                        {
                            temp2 = 2;
                            tempindex2 = tempindex2 - 1;
                        }
                        else
                        {
                            
                                return false;
                            
                        }
                    }   
                    else
                    {
                        if(temp1==1||temp3==1)
                        {
                            return false;
                        }
                        
                    }
                }

                if (list[i] == '(')
                {
                    temp3 = 1;
                    tempindex3 = i;
                }
                if (list[i] == ')')
                {
                    if (temp3 < 1)
                    {
                        return false;

                    }
                    else if (temp3 == 1)
                    {
                        if (tempindex3 > tempindex2 && tempindex3 > tempindex1)
                        {
                            temp3 = 2;
                            tempindex3 = tempindex3 - 1;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (temp1 == 1 || temp2 == 1)
                        {
                            return false;
                        }
                       
                    }
                }
            }

            if (temp1 == 1 || temp2 == 1 || temp3 == 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public bool IsValid2(string s)
        {
            Stack<char> st = new Stack<char>();
            Hashtable ht = new Hashtable() { { ')', '(' }, { '}', '{' }, { ']', '[' } };
            for (int i = 0; i < s.Length; i++)
            {
                if (ht.ContainsValue(s[i]))
                {
                    st.Push(s[i]);//如果是左括号，入栈
                }
                else if (st.Count == 0 || st.Pop() != (char)ht[s[i]])//右括号且栈为空，或者栈顶左括号不匹配，false
                {
                    return false;
                }
            }
            return st.Count == 0;//如果栈为空，括号全部配对完，返回true
        }
        public bool IsValid3(string s)
        {
            Stack<char> stack = new Stack<char>();
            Hashtable hashtable = new Hashtable() { { ')', '(' }, { ']', '[' }, { '}', '{' } };
            for(int i=0;i<s.Length;i++)
            {
                if (hashtable.ContainsValue(s[i]))
                {
                    stack.Push(s[i]);
                }
                else if(stack.Count==0||stack.Pop()!=(char)hashtable[s[i]])
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }


    }
}
