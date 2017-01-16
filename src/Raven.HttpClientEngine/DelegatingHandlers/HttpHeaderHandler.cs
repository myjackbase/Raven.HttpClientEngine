using Raven.HttpClientEngine.MessageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Raven.HttpClientEngine.DelegatingHandlers
{
    public class HttpHeaderHandler : DelegatingHandler
    {
        HttpRequestMessageOptions _options;

        public HttpHeaderHandler(HttpRequestMessageOptions options)
        {
            _options = options;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            foreach (var header in _options.Headers)
            {
                request.Headers.Add(header.Key, header.Value.ToString());
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
