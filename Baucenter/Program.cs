using BlaBlaCar;
using System;
using System.Net;


namespace Baucenter
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = "416001653";
            var postRequest = new PostRequest("https://baucenter.ru/");
            var Proxy = new WebProxy("127.0.0.1:8888");
            var cookieContainer = new CookieContainer();

            postRequest.Data = $"ajax_call=y&INPUT_ID=title-search-input&q={code}&l=2";
            postRequest.Accept = "*/*";
            postRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36";
            postRequest.ContentType = "application/x-www-form-urlencoded";
            postRequest.Refer = "https://baucenter.ru/";
            postRequest.Host = "baucenter.ru";
            postRequest.Proxy = Proxy;

            postRequest.Headers.Add("Bx-ajax", "true");
            postRequest.Headers.Add("Origin", "https://baucenter.ru");
            postRequest.Headers.Add("sec-ch-ua", "\"Google Chrome\";v=\"93\", \"Not; A Brand\";v=\"99\", \"Chromium\";v=\"93\"");
            postRequest.Headers.Add("sec-ch-ua-mobile", "?0");
            postRequest.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
            postRequest.Headers.Add("Sec-Fetch-Dest", "empty");
            postRequest.Headers.Add("Sec-Fetch-Mode", "cors");
            postRequest.Headers.Add("Sec-Fetch-Site", "same-origin");


            postRequest.Run(cookieContainer);


            var strStart = postRequest.Response.IndexOf("search-result-group search-result-product");
            strStart = postRequest.Response.IndexOf("<a href=", strStart) + 9;
            var strEnd = postRequest.Response.IndexOf("\"", strStart);
            var getPath = postRequest.Response.Substring(strStart, strEnd - strStart);
            Console.WriteLine(getPath);
            Console.ReadKey();

            var getRequest = new GetRequest($"https://baucenter.ru{getPath}");
            getRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            getRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36";
            getRequest.Refer = "https://baucenter.ru/";
            getRequest.Host = "baucenter.ru";
            getRequest.Proxy = Proxy;

            getRequest.Headers.Add("sec-ch-ua", "\"Google Chrome\";v=\"93\", \"Not; A Brand\";v=\"99\", \"Chromium\";v=\"93\"");
            getRequest.Headers.Add("sec-ch-ua-mobile", "?0");
            getRequest.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
            getRequest.Headers.Add("Sec-Fetch-Dest", "document");
            getRequest.Headers.Add("Sec-Fetch-Mode", "navigate");
            getRequest.Headers.Add("Sec-Fetch-Site", "same-origin");
            getRequest.Headers.Add("Sec-Fetch-User", "?1");
            getRequest.Headers.Add("Upgrade-Insecure-Requests", "1");
            getRequest.Run(cookieContainer);
            
        }
    }
}

