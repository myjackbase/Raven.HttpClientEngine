using Raven.HttpClientEngine.DelegatingHandlers;
using Raven.HttpClientEngine.MessageOptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.HttpClientEngine.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("E:\\log123.txt", FileMode.OpenOrCreate);

            HttpRequestMessageOptions httpRequestMessageOptions = new HttpRequestMessageOptions();
            httpRequestMessageOptions.Headers.Add(new KeyValuePair<string, string>("user", "ktapi"));
            httpRequestMessageOptions.Headers.Add(new KeyValuePair<string, string>("pwd", "0306C3"));

            HttpClient client = HttpClientFactory.Create(
                new HttpHeaderHandler(httpRequestMessageOptions),
                new HttpTraceLogHandler(stream)
            );
            client.BaseAddress = new Uri("http://www.cnblogs.com/");

            HttpRequestMessage request = new HttpRequestMessage();
            var res = client.SendAsync(request).Result;

            Console.ReadLine();
        }
    }
}
