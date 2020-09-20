using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.game
{
    public class reorderSpaces
    {
        public static string ReorderSpaces(string text)
        {

            
            int spacecount = 0;
            
            foreach (char node in text)
            {
                if (char.IsWhiteSpace(node))
                {
                    spacecount++;
                }
            }
            if(spacecount==0)
            {
                return text;
            }
            string[] list = text.Split(" ");
           
            List<string> strlist = new List<string>();

            foreach(string node in list)
            {
                if (!string.IsNullOrWhiteSpace(node))
                {
                    strlist.Add(node);
                }
            }
            StringBuilder outlist = new StringBuilder();
            if (strlist.Count==1)
            {
                outlist.Append(strlist[0]);
                for (int j = 0; j < spacecount; j++)
                {
                    outlist.Append(" ");
                }
                return outlist.ToString();
            }

            int spaceNode = spacecount / (strlist.Count-1);
            
            int lastspace= spacecount % (strlist.Count-1);

          
            for(int i=0;i<strlist.Count;i++)
            {
                outlist.Append(strlist[i]);
                if(i==strlist.Count-1)
                {
                    for(int j=0;j< lastspace; j++)
                    {
                        outlist.Append(" ");
                    }
                }
                else
                {
                    for (int j = 0; j < spaceNode; j++)
                    {
                        outlist.Append(" ");
                    }
                }
            }

            return outlist.ToString();

    }
    }
}
