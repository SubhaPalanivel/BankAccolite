using System.Net;
namespace BankTestProject_1.ServiceRequest
{
    public class SetRequest
    {
        public HttpWebRequest SetPUTRequest(string url, string content, string json)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "PUT";
            request.ContentType = content;
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(json);
            }
            return request;
        }
        public HttpWebRequest SetDeleteRequest(string url, string content)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "DELETE";
            request.ContentType = content;
            return request;
        }

        public HttpWebRequest SetGetRequest(string url, string content)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = content;
            return request;
        }
    }
}
