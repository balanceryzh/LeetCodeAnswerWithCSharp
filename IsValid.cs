using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
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
    }
}
