using CSRedis;
using System;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //    int[] list = { 3, 5, 1 };
            //int[] i=    leecode1(list, 8);
            //string s = "sd";
            //bool ts = IsRepeat2(s);
            //bubbling(list);

            //Console.WriteLine(i);
            //Console.ReadLine();
            //GenericCacheTest<int>.SetCache("a", 12345);
            //Console.WriteLine(GenericCacheTest<int>.GetCache("a"));
            //RedisTest.Redisconnection("192.168.1.99:6379");
            //RedisTest pr = new RedisTest();
            //RedisHelper.Set("hello", "1");
            ////pr.SendVerifyCode("abcdefg");
            ////LengthOfLongestSubstring.LengthOfLongestSubstring3("asdasdaa");

            //Console.WriteLine(pr.VerifyCode("hello").Result);
            //Console.WriteLine(RedisHelper.Get("hello"));
            //RedisHelper.Del("hello");
            //Console.WriteLine(RedisHelper.Get("hello"));
     
            Console.WriteLine(IsValid.IsValid1("[({ (())}[()])]"));
        }


   
       

        public static bool IsRepeat(string InString)
        {
          
            char[] charlist = InString.ToCharArray();
            bool[] ascii = new bool[127];
           for(int i=0;i<charlist.Length;i++)
            {
                if(ascii[charlist[i]])
                {
                    return true;
                }
                else
                {
                    ascii[charlist[i]] = true;
                }
            }

            return false;
        }

        public static bool IsRepeat2(string InString)
        {
            char[] charlist = InString.ToCharArray();
            for(int i=0;i<charlist.Length;i++)
            {
                for(int j=i+1;j<charlist.Length;j++)
                {
                    if(charlist[i]== charlist[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static int[] bubbling(int[] insort)
        {
            for(int i=0;i<insort.Length;i++)
            {
                for(int j=i+1;j<insort.Length;j++)
                {
                    if(insort[i]>insort[j])
                    {
                        int z = insort[i];
                        insort[i] = insort[j];
                        insort[j] = z;
                    }
                }
            }

            return insort;
        }

        //public static int[] quick()
        //{

        //}
        public static int[] leecode1(int[] list,int sums)
        {
            int a = 0;
            int b = 0;
            for(int i=0;i< list.Length;i++)
            {
                for(int j=i+1;j<list.Length;j++)
                {
                    int z = list[i] + list[j];
                    if(z==sums)
                    {
                        a = i;
                        b = j;
                    }
                }
            }
            return new int[]{a,b };
        }


    }

    
}
