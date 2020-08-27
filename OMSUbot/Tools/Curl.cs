using System;
using System.IO;
using System.Net;
using System.Text;

namespace OMSUbot.Tools
{
    public static class Curl
    {

        public static string Curl2String(string url)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(
                resp.GetResponseStream(), Encoding.UTF8))
            {
                return stream.ReadToEnd();
            }
        }

        public static dynamic Curl2Json(string url)
        {
            string response = Curl2String(url);
            return Json.Decode(response);
        }

        public static void DownloadFile(string url, string fileName)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, fileName);
            }
        }
    }
}