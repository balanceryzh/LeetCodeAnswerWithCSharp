using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public class GenericCacheTest<T> where T : new()
    {
        static GenericCacheTest()
        {
            _TypeTimeDictionary = new Dictionary<string, T>();
            //Console.WriteLine("This is GenericCache 静态构造函数");
            //_TypeTime = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
        }

        // private static string _TypeTime = "";
        private static Dictionary<string, T> _TypeTimeDictionary = null;
        //public static string GetCache()
        //{
        //    return _TypeTime;
        //}
        public static T GetCache(string keyName)
        {


            if (_TypeTimeDictionary.ContainsKey(keyName))
            {
                return _TypeTimeDictionary[keyName];
            }
            else
            {
                T temp = new T();
                return temp;
            }

        }


        public static void SetCache(string keyName, T Value)
        {
            _TypeTimeDictionary.Add(keyName, Value);

        }
        public static void DelCache(string keyName)
        {
            _TypeTimeDictionary.Remove(keyName);

        }
    }

    public class GenericCacheTestString
    {
        static GenericCacheTestString()
        {
            _TypeTimeDictionary = new Dictionary<string, string>();
            //Console.WriteLine("This is GenericCache 静态构造函数");
            //_TypeTime = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
        }

        // private static string _TypeTime = "";
        private static Dictionary<string, string> _TypeTimeDictionary = null;
        //public static string GetCache()
        //{
        //    return _TypeTime;
        //}
        public static string GetCache(string keyName)
        {


            if (_TypeTimeDictionary.ContainsKey(keyName))
            {
                return _TypeTimeDictionary[keyName];
            }
            else
            {

                return "没有缓存";
            }

        }


        public static void SetCache(string keyName, string Value)
        {
            _TypeTimeDictionary.Add(keyName, Value);

        }
        public static void DelCache(string keyName)
        {
            _TypeTimeDictionary.Remove(keyName);

        }
    }
}