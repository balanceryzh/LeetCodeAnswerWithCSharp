using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public class IsOneEditDistance161
    {
        public bool IsOneEditDistance(string s, string t)
        {
            if (s.Length - t.Length > 1 || s.Length - t.Length < -1||s==t)
            {
                return false;
            }
            else if(s.Length+t.Length==1)
            {
                return true;
            }
            else
            {
                int tempi = 0;
                if(s.Length==t.Length)
                {
                    for(int i=0;i<s.Length;i++)
                    {
                        if(s[i]!=t[i])
                        {
                            tempi++;
                            if(tempi>1)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
     
                else
                {
                    Stack s1 = new Stack();
                    for(int i=0;i<s.Length;i++)
                    {
                        s1.Push(s[i]);
;                    }
                    Stack t1 = new Stack();
                    for (int i = 0; i < t.Length; i++)
                    {
                        t1.Push(t[i]);
                    }

                    while(s1.Count>0)
                    {
                        if (s.Length > t.Length)
                        {
                            if (t1.Count == 0 || s1.Peek().ToString() != t1.Peek().ToString())
                            {
                                s1.Pop();
                                tempi++;
                                if(tempi>1)
                                {
                                    return false;
                                }
                                
                            }
                            else
                            {
                                s1.Pop();
                                t1.Pop();
                                
                            }
                        }
                        else
                        {
                            if (s1.Count == 0 || s1.Peek().ToString() != t1.Peek().ToString())
                            {
                                t1.Pop();
                                tempi++;
                                if (tempi > 1)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                s1.Pop();
                                t1.Pop();
                            }

                        }
                    }
                    return true;
                }
            }
        }
    }
}
