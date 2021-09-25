using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BlaBlaCar
{
    public class GetRequest

    {
        HttpWebRequest request;
        string adress;
        public string Response { get; set; }

        public string Accept { get; set; }

        public string Host { get; set; }
        public string Refer { get; set; }
        public string UserAgent { get; set; }




        public WebProxy Proxy { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public GetRequest(string adress)
        {
            this.adress = adress;
            Headers = new Dictionary<string, string>();

        }
        public void Run()
        {
            request = (HttpWebRequest)WebRequest.Create(adress);
            request.Method = "Get";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    Response = new StreamReader(stream).ReadToEnd();
                }
            }
            catch (Exception)
            {

            }

        }

        public void Run(CookieContainer cookieContainer)
        {
            request = (HttpWebRequest)WebRequest.Create(adress);
            request.Method = "Get";
            request.CookieContainer = cookieContainer;
            request.Proxy = Proxy;
            request.Host = Host;
            request.Accept = Accept;
            request.UserAgent = UserAgent;
            request.Referer = Refer;


            foreach (var pair in Headers)
            {
                request.Headers.Add(pair.Key, pair.Value);
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    Response = new StreamReader(stream).ReadToEnd();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}