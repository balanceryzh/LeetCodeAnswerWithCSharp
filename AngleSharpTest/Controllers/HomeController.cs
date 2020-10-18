using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AngleSharpTest.Models;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AngleSharp.Html.Parser;
using AngleSharp.Dom;
using HtmlAgilityPack;

namespace AngleSharpTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public void itemList(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            htmlWeb.OverrideEncoding = Encoding.GetEncoding("gb2312");
            HtmlDocument htmlDoc = htmlWeb.Load(url);
            var requirement = htmlDoc.DocumentNode.SelectNodes("//div[@class='bmsg job_msg inbox']/p").AsParallel().ToList();
            var name= htmlDoc.DocumentNode.SelectNodes("//p[@class='cname']/a[@class='catn']").AsParallel().ToList();
            var place = htmlDoc.DocumentNode.SelectNodes("//div[@class='cn']/strong").AsParallel().ToList();
        }

        public IActionResult Index()
        {
            //JObject jObject = JobList("https://search.51job.com/list/020000,000000,0000,00,9,99,C%2523,2,1.html?lang=c&postchannel=0000&workyear=99&cotype=99&degreefrom=99&jobterm=99&companysize=99&ord_field=0&dibiaoid=0&line=&welfare=");
            JObject jObject = JobList("https://search.51job.com/list/020000,000000,0000,00,9,16000-25000,C%2523,2,1.html?lang=c&postchannel=0000&workyear=99&cotype=99&degreefrom=99&jobterm=99&companysize=99&ord_field=0&dibiaoid=0&line=&welfare=");

            var pages = jObject["total_page"];
            List<string> hrefList = new List<string>();

            if (!string.IsNullOrEmpty(pages?.ToString()))
            {
                for (int i = 1; i <= Convert.ToInt32(pages.ToString()); i++)
                {
                    string url = "https://search.51job.com/list/020000,000000,0000,00,9,16000-25000,C%2523,2," + i + ".html?lang=c&postchannel=0000&workyear=99&cotype=99&degreefrom=99&jobterm=99&companysize=99&ord_field=0&dibiaoid=0&line=&welfare=";
                    var TempjObject=JobList(url);
                    var node = TempjObject["engine_search_result"];
                    foreach(var item in node)
                    {
                        string temp=item["job_href"].ToString();
                        hrefList.Add(temp);
                    }

                }
            }
            return View();
        }

        private static JObject JobList(string url)
        {
            //HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://search.51job.com/list/020000,000000,0000,00,9,99,C%2523,2,1.html?lang=c&postchannel=0000&workyear=99&cotype=99&degreefrom=99&jobterm=99&companysize=99&ord_field=0&dibiaoid=0&line=&welfare=");
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)myReq.GetResponse();
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.GetEncoding("gb2312"));

            var list = readStream.ReadToEnd();

            string head = "window.__SEARCH_RESULT__ = ";
            string end = "</script>";
            int temp = list.IndexOf(head);
            int temp2 = list.IndexOf(end, temp);
            string liststring = list.Substring(temp + head.Length, temp2 - temp - head.Length);
            JObject jObject = (JObject)JsonConvert.DeserializeObject(liststring);
           
            return jObject;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
