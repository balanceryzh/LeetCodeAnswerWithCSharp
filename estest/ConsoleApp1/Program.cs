using System;
using Microsoft.Extensions.Configuration;
using PlainElastic.Net;

namespace ConsoleApp1
{
    class Program
    {

        //Install-Package Microsoft.Extensions.Configuration
        //Install-Package Microsoft.Extensions.Configuration.Json
        //https://www.cnblogs.com/libingql/p/11326358.html 读取json
        //https://www.cnblogs.com/lwqlun/p/9736391.html  读取json
        //https://blog.csdn.net/weixin_42704736/article/details/81154657  安装kibana
        //注意设置跨域
        //http.cors.allow-origin: "/.*/"
        //http.cors.enabled: true
        //https://www.cnblogs.com/zgqys1980/archive/2011/09/08/2171371.html 需要设置解析 JSON
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("test.json");
            var config = builder.Build();
            var  Connection = new ElasticConnection("localhost", 9200);
            var test1 = config["EsTermConnection"];
            Console.WriteLine("Hello World!");
        }
    }
}
