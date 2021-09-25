using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BlaBlaCar
{
    public class PostRequest

    {
        HttpWebRequest request;
        string adress;
        public string Response { get; set; }

        public string Accept { get; set; }

        public string Host { get; set; }

        public string ContentType { get; set; }
        public string Refer { get; set; }
        public string UserAgent { get; set; }

        public string Data { get; set; }

        public WebProxy Proxy { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public PostRequest(string adress)
        {
            this.adress = adress;
            Headers = new Dictionary<string, string>();

        }
        
        public void Run(CookieContainer cookieContainer)
        {
            request = (HttpWebRequest)WebRequest.Create(adress);
            request.Method = "Post";
            request.CookieContainer = cookieContainer;
            request.Proxy = Proxy;
            request.Host = Host;
            request.Accept = Accept;
            request.ContentType = ContentType;
            request.UserAgent = UserAgent;
            request.Referer = Refer;

            byte[] sendData = Encoding.UTF8.GetBytes(Data);
            request.ContentLength = sendData.Length;
            Stream sendStream = request.GetRequestStream();
            sendStream.Write(sendData, 0, sendData.Length);
            sendStream.Close();

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
