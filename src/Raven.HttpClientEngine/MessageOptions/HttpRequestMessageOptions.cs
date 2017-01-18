using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.HttpClientEngine.MessageOptions
{
    public class HttpRequestMessageOptions : HttpMessageOptions
    {
        public List<KeyValuePair<string, string>> CustomHeaders { get; set; }

        public string BaseAddress { get; set; }

        public string RequestUri { get; set; }

        public int TimeOut { get; set; }

        public HttpRequestMessageOptions()
        {
            CustomHeaders = new List<KeyValuePair<string, string>>();
        }

        public HttpRequestMessageOptions(string baseAddr, string requestUri, int timeOut = 10000)
        {
            BaseAddress = baseAddr;
            RequestUri = requestUri;
            TimeOut = timeOut;
            CustomHeaders = new List<KeyValuePair<string, string>>();
        }
    }
}
