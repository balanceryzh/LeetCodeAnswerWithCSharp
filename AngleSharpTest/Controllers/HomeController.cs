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
using AngleSharpTest.DataBase;
using System.Threading;

namespace AngleSharpTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public JobMession itemList(string urls)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            htmlWeb.OverrideEncoding = Encoding.GetEncoding("gb2312");

            JobMession jobmession = new JobMession() { url = urls };
            IEnumerable<JobMession> list = MysqlDataBase.select<JobMession>("select * from jobList where url=@url", jobmession);
            //if (list.Count() >0)
            //{
            //    if (string.IsNullOrEmpty(list.ToList()[0].requirement) || string.IsNullOrWhiteSpace(list.ToList()[0].requirement) ||list.ToList()[0].state!="-4")
            //    {
            //        HtmlDocument htmlDoc = htmlWeb.Load(urls);
            //        var requirementlist = htmlDoc.DocumentNode.SelectNodes("//div[@class='bmsg job_msg inbox']")?.AsParallel().ToList();
            //        string requirement = "";
            //        if (requirementlist != null)
            //        {
            //            foreach (var node in requirementlist)
            //            {
            //                requirement = requirement + node.InnerText + " ";
            //            }
            //        }
            //        var Compynamelist = htmlDoc.DocumentNode.SelectNodes("//p[@class='cname']/a[@class='catn']")?.AsParallel().ToList();
            //        string Compyname = "";
            //        if (Compynamelist != null)
            //        {
            //            foreach (var node in Compynamelist)
            //            {
            //                Compyname = Compyname + node.InnerText + " ";
            //            }
            //        }
            //        var addresslist = htmlDoc.DocumentNode.SelectNodes("//div[@class='bmsg inbox']/p")?.AsParallel().ToList();
            //        string address = "";
            //        if (addresslist != null)
            //        {
            //            foreach (var node in addresslist)
            //            {
            //                address = address + node.InnerText + " ";
            //            }
            //        }

            //        var placelist = htmlDoc.DocumentNode.SelectNodes("//div[@class='cn']/strong")?.AsParallel().ToList();
            //        string place = "";
            //        if (placelist != null)
            //        {
            //            foreach (var node in placelist)
            //            {
            //                place = place + node.InnerText + " ";
            //            }
            //        }

            //        var namelist = htmlDoc.DocumentNode.SelectNodes("//div[@class='cn']/h1")?.AsParallel().ToList();
            //        string name = "";
            //        if (namelist != null)
            //        {
            //            foreach (var node in namelist)
            //            {
            //                name = name + node.InnerText + " ";
            //            }

            //        }


            //        jobmession.id = list.ToList()[0].id;

            //        jobmession.requirement = requirement;

            //        jobmession.creatDate = DateTime.Now;
            //        jobmession.state = outstate(list.ToList()[0]);

            //        MysqlDataBase.insertOrupdate("update  jobList set requirement=@requirement,creatDate=@creatDate,state=@state where id=@id", jobmession);
            //        Thread.Sleep(500);
            //    }
            //    else
            //    {
            //        jobmession.id = list.ToList()[0].id;

            //        jobmession.requirement = list.ToList()[0].requirement;

            //        jobmession.creatDate = DateTime.Now;
            //        var tempstate = outstate(list.ToList()[0]);
            //        if (jobmession.state != tempstate)
            //        {
            //            jobmession.state = tempstate;
            //            MysqlDataBase.insertOrupdate("update  jobList set requirement=@requirement,creatDate=@creatDate,state=@state where id=@id", jobmession);
            //        }
            //    }
            //}
            //else
            //{
            //    HtmlDocument htmlDoc = htmlWeb.Load(urls);
            //    var requirementlist = htmlDoc.DocumentNode.SelectNodes("//div[@class='bmsg job_msg inbox']")?.AsParallel().ToList();
            //    string requirement = "";
            //    if (requirementlist != null)
            //    {
            //        foreach (var node in requirementlist)
            //        {
            //            requirement = requirement + node.InnerText + " ";
            //        }
            //    }
            //    var Compynamelist = htmlDoc.DocumentNode.SelectNodes("//p[@class='cname']/a[@class='catn']")?.AsParallel().ToList();
            //    string Compyname = "";
            //    if (Compynamelist != null)
            //    {
            //        foreach (var node in Compynamelist)
            //        {
            //            Compyname = Compyname + node.InnerText + " ";
            //        }
            //    }
            //    var addresslist = htmlDoc.DocumentNode.SelectNodes("//div[@class='bmsg inbox']/p")?.AsParallel().ToList();
            //    string address = "";
            //    if (addresslist != null)
            //    {
            //        foreach (var node in addresslist)
            //        {
            //            address = address + node.InnerText + " ";
            //        }
            //    }

            //    var placelist = htmlDoc.DocumentNode.SelectNodes("//div[@class='cn']/strong")?.AsParallel().ToList();
            //    string place = "";
            //    if (placelist != null)
            //    {
            //        foreach (var node in placelist)
            //        {
            //            place = place + node.InnerText + " ";
            //        }
            //    }

            //    var namelist = htmlDoc.DocumentNode.SelectNodes("//div[@class='cn']/h1")?.AsParallel().ToList();
            //    string name = "";
            //    if (namelist != null)
            //    {
            //        foreach (var node in namelist)
            //        {
            //            name = name + node.InnerText + " ";
            //        }

            //    }


            //    jobmession.id = Guid.NewGuid().ToString();
            //    jobmession.name = name;
            //    jobmession.place = place;
            //    jobmession.requirement = requirement;
            //    jobmession.address = address;
            //    jobmession.Compyname = Compyname;
            //    jobmession.creatDate = DateTime.Now;

            //    jobmession.state = outstate(jobmession);
            //    MysqlDataBase.insertOrupdate("insert into jobList values(@id,@url,@requirement,@Compyname,@name,@address,@place,@creatDate,@state)", jobmession);
            //    Thread.Sleep(500);

            //}

          
      
            if (list.Count() == 0)
            {
                HtmlDocument htmlDoc = htmlWeb.Load(urls);
                var requirementlist = htmlDoc.DocumentNode.SelectNodes("//div[@class='bmsg job_msg inbox']")?.AsParallel().ToList();
                string requirement = "";
                if (requirementlist != null)
                {
                    foreach (var node in requirementlist)
                    {
                        requirement = requirement + node.InnerText + " ";
                    }
                }
                var Compynamelist = htmlDoc.DocumentNode.SelectNodes("//p[@class='cname']/a[@class='catn']")?.AsParallel().ToList();
                string Compyname = "";
                if (Compynamelist != null)
                {
                    foreach (var node in Compynamelist)
                    {
                        Compyname = Compyname + node.InnerText + " ";
                    }
                }
                var addresslist = htmlDoc.DocumentNode.SelectNodes("//div[@class='bmsg inbox']/p")?.AsParallel().ToList();
                string address = "";
                if (addresslist != null)
                {
                    foreach (var node in addresslist)
                    {
                        address = address + node.InnerText + " ";
                    }
                }

                var placelist = htmlDoc.DocumentNode.SelectNodes("//div[@class='cn']/strong")?.AsParallel().ToList();
                string place = "";
                if (placelist != null)
                {
                    foreach (var node in placelist)
                    {
                        place = place + node.InnerText + " ";
                    }
                }

                var namelist = htmlDoc.DocumentNode.SelectNodes("//div[@class='cn']/h1")?.AsParallel().ToList();
                string name = "";
                if (namelist != null)
                {
                    foreach (var node in namelist)
                    {
                        name = name + node.InnerText + " ";
                    }

                }


                jobmession.id = Guid.NewGuid().ToString();
                jobmession.name = name;
                jobmession.place = place;
                jobmession.requirement = requirement;
                jobmession.address = address;
                jobmession.Compyname = Compyname;
                jobmession.creatDate = DateTime.Now;

                jobmession.state = outstate(jobmession);
                MysqlDataBase.insertOrupdate("insert into jobList values(@id,@url,@requirement,@Compyname,@name,@address,@place,@creatDate,@state,@isNo)", jobmession);
                Thread.Sleep(500);

            }



            return jobmession;
        }
        public string outstate(JobMession jobmession)
        {
            string state = "0";
            string requirement = jobmession.requirement;
            string name = jobmession.name;
            string address = jobmession.address;
            string compyname = jobmession.Compyname;
            if (requirement.Contains("wpf") || requirement.Contains("WPF") || requirement.Contains("WinForm") || requirement.Contains("Winform") || requirement.Contains("WINFORM") || requirement.Contains("winform") || requirement.Contains("win form") || requirement.Contains("win Form") || requirement.Contains("GIS")||requirement.Contains("桌面")|| requirement.Contains("PLC")|| requirement.Contains("SAP"))
            {
                state = state + "1";
            }
            if (requirement.Contains("上位机") || requirement.Contains("嵌入"))
            {
                state = state + "2";
            }
            if (requirement.Contains("游戏") || requirement.Contains("u3d") || requirement.Contains("Unity3D") || requirement.Contains("Unity") || requirement.Contains("unity"))
            {
                state = state + "3";
            }
            //if (requirement.Contains("java") || requirement.Contains("JAVA") || requirement.Contains("Java"))
            //{
            //    state = state + "4";
            //}
            if (requirement.Contains("linux") || requirement.Contains("LINUX") || requirement.Contains("Linux"))
            {
                state = state + "5";
            }
            if (requirement.Contains("公众号")|| requirement.Contains("机器视觉")|| requirement.Contains("视觉")|| requirement.Contains("CAD") || requirement.Contains("图像处理") || requirement.Contains("驱动开发") || requirement.Contains("半导体") || requirement.Contains("数字化") || requirement.Contains("硬件"))
            {
                state = state + "6";
            }
            if (requirement.Contains("EXTJS"))
            {
                state = state + "7";
            }
            if (requirement.Contains("DevExpress"))
            {
                state = state + "8";
            }
            if (requirement.Contains("TCP/IP")|| requirement.Contains("OPC") || requirement.Contains("TCP"))
            {
                state = state + "9";
            }
            if (requirement.Contains("DirectX")|| requirement.Contains("OpenGL"))
            {
                state = state + "A";
            }
            if (requirement.Contains("C语言")|| requirement.Contains("英语读写")|| requirement.Contains("移动") || requirement.Contains("qt") || requirement.Contains("QT")||requirement.Contains("异地") || requirement.Contains("AR") || requirement.Contains("VR") || requirement.Contains("MR") || requirement.Contains("URS")||requirement.Contains("阿里云") || requirement.Contains("风险") || requirement.Contains("本地应用")|| requirement.Contains("SOA") || requirement.Contains("人工智能") || requirement.Contains("Lab") || requirement.Contains("LAB")|| requirement.Contains("CET") || requirement.Contains("四") || requirement.Contains("八") || requirement.Contains("建筑") || requirement.Contains("外包")|| requirement.Contains("SaaS")|| requirement.Contains("PLM"))
            {
                state = state + "B";
            }
            if (name.Contains("校园") || name.Contains("校招") || name.Contains("学校")|| name.Contains("经理")|| name.Contains("架构")|| name.Contains("主管") || name.Contains("总监")|| name.Contains("测试") || name.Contains("PHP") || name.Contains("C++")|| name.Contains("Python")|| name.Contains("VR") || name.Contains("质量保证") || name.Contains("顾问") || name.Contains("打印")|| name.Contains("AWS")|| name.Contains("AI")|| name.Contains("日") || name.Contains("苏州")|| name.Contains("制造")|| name.Contains("算法")|| name.Contains("LIMS")  || name.Contains("电子") || name.Contains("上位机") || name.Contains("游戏"))
            {
                state = "-1";
                return state;
            }
            if (address.Contains("松江") || address.Contains("青浦")|| address.Contains("奉贤")|| address.Contains("临港") || address.Contains("金山") || address.Contains("江苏") || string.IsNullOrEmpty(address)||string.IsNullOrWhiteSpace(address))
            {
                state = "-2";
                return state;
            }
            if (requirement.Contains("全日制本")|| requirement.Contains("全日制")|| requirement.Contains("硕士")||requirement.Contains("28岁") || requirement.Contains("35") || requirement.Contains("30") || requirement.Contains("33") || requirement.Contains("38")||requirement.Contains("量化")|| requirement.Contains("机器人")|| requirement.Contains("自动化")|| requirement.Contains("运维")|| requirement.Contains("知名"))
            {
                state = "-3";
                return state;
            }
            if(string.IsNullOrEmpty(compyname.Trim())|| string.IsNullOrWhiteSpace(compyname.Trim()))
            {
                state = "-4";
                return state;
            }
            return state;
        }
        public IActionResult Index()
        {
            JobMession jobmession = new JobMession() { state = "0" };
            IEnumerable<JobMession> list = MysqlDataBase.select<JobMession>("select * from jobList where state=@state", jobmession);
            foreach(var node in list)
            {
                jobmession.id = node.id;

                jobmession.requirement = node.requirement;

                jobmession.creatDate = DateTime.Now;
                var tempstate = outstate(node);
                if (jobmession.state != tempstate)
                {
                    jobmession.state = tempstate;
                    MysqlDataBase.insertOrupdate("update jobList set requirement=@requirement,creatDate=@creatDate,state=@state where id=@id", jobmession);
                }
            }
            
          
           
            return View();
        }
        public IActionResult Index1()
        {
            //JObject jObject = JobList("https://search.51job.com/list/020000,000000,0000,00,9,99,C%2523,2,1.html?lang=c&postchannel=0000&workyear=99&cotype=99&degreefrom=99&jobterm=99&companysize=99&ord_field=0&dibiaoid=0&line=&welfare=");
            JObject jObject = JobList("https://search.51job.com/list/020000,000000,0000,00,9,13000-25000,C%2523,2,1.html?lang=c&postchannel=0000&workyear=99&cotype=99&degreefrom=99&jobterm=99&companysize=99&ord_field=0&dibiaoid=0&line=&welfare=");

            var pages = jObject["total_page"];
            List<string> hrefList = new List<string>();
            List<JobMession> JobMessionList = new List<JobMession>();
            if (!string.IsNullOrEmpty(pages?.ToString()))
            {
                for (int i = 1; i <= Convert.ToInt32(pages.ToString()); i++)
                {

                    string url = "https://search.51job.com/list/020000,000000,0000,00,9,13000-25000,C%2523,2," + i + ".html?lang=c&postchannel=0000&workyear=99&cotype=99&degreefrom=99&jobterm=99&companysize=99&ord_field=0&dibiaoid=0&line=&welfare=";
                    var TempjObject = JobList(url);

                    var node = TempjObject["engine_search_result"];
                    foreach (var item in node)
                    {
                        string temp = item["job_href"].ToString();
                        JobMessionList.Add(itemList(temp));
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
