using Raven.HttpClientEngine.DelegatingHandlers;
using Raven.HttpClientEngine.MessageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.HttpClientEngine
{
    public class HttpClientEngine
    {
        private HttpClient _client;
        private HttpRequestMessageOptions _requestOptions;
        private HttpResponseMessageOptions _responseOptions;

        public HttpClientEngine(HttpRequestMessageOptions requestOptions, HttpResponseMessageOptions responseOptions)
        {
            _requestOptions = requestOptions;
            _responseOptions = responseOptions;
            _client = HttpClientFactory.Create(
                 new HttpHeaderHandler(_requestOptions),
                 new HttpTraceLogHandler(_responseOptions),
                 new HttpHeaderHandler(_requestOptions)
             );
        }

        public async Task<string> SendAsync()
        {
            using (HttpRequestMessage request = new HttpRequestMessage())
            {
                var response = await _client.SendAsync(request);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
