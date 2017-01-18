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
    public class HttpUriHandler : DelegatingHandler
    {
        HttpRequestMessageOptions _options;

        public HttpUriHandler(HttpRequestMessageOptions options)
        {
            _options = options;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.RequestUri = new Uri(string.Concat(_options.BaseAddress, _options.RequestUri));

            return base.SendAsync(request, cancellationToken);
        }
    }
}
