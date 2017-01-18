using Raven.HttpClientEngine.MessageOptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.HttpClientEngine.DelegatingHandlers
{
    public class HttpTraceLogHandler : DelegatingHandler
    {
        StreamWriter _writer;
        HttpResponseMessageOptions _options;

        public HttpTraceLogHandler(HttpResponseMessageOptions options)
        {
            _writer = new StreamWriter(stream);
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                _writer.WriteLine("{0}\t{1}\t{2}", request.RequestUri,
                    (int)response.StatusCode, response.Headers.Date);
            }

            foreach (var header in response.Headers)
            {
                _writer.WriteLine("{0}:{1}", header.Key, string.Join(",", header.Value));
            }

            _writer.WriteLine("{0}\t{1}\t{2}\t{3}", request.RequestUri,
                    (int)response.StatusCode, response.Headers.Date, await response.Content.ReadAsStringAsync());
            _writer.Close();
            return response;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // _writer.Close();
                _writer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
