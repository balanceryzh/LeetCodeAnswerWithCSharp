using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public class DictionaryCache
    {
        private static Dictionary<Type, string> _TypeTimeDictionary = null;
        static DictionaryCache()
        {
            Console.WriteLine("This is DictionaryCache 静态构造函数");
            _TypeTimeDictionary = new Dictionary<Type, string>();
        }
        public static string GetCache<T>()
        {
            Type type = typeof(Type);
            if (!_TypeTimeDictionary.ContainsKey(type))
            {
                _TypeTimeDictionary[type] = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
            }
            return _TypeTimeDictionary[type];
        }


    }

    public class GenericCacheTest<T>
    {
        static GenericCacheTest()
        {
            //Console.WriteLine("This is GenericCache 静态构造函数");
            //_TypeTime = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
        }

        private static string _TypeTime = "";
        private static Dictionary<string, T> _TypeTimeDictionary2 = null;
        //public static string GetCache()
        //{
        //    return _TypeTime;
        //}
        public static T GetCache(string keyName)
        {
            return _TypeTimeDictionary2[keyName];
        }


        public static void SetCache(string keyName,T Value)
        {
            _TypeTimeDictionary2[keyName] = Value;
        }
    }
}
