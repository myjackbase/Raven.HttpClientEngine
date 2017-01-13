using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.HttpClientEngine
{
    /// <summary>
    /// The Options of HttpMessage
    /// </summary>
    public class HttpMessageOptions
    {
        private const string DefaultValue = "*";
        private string _requestUri = DefaultValue;
        private HttpContent _httpContent;
        private string _httpContentSerialized;

        /// <summary>
        /// Required: The Url we are targetting
        /// </summary>
        public string RequestUri
        {
            get { return _requestUri; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "RequestUri cannot be null/empty/whitespace.Please choose a valid value");
                }
                _requestUri = value;
            }
        }

        /// <summary>
        /// Optional: If not provided, then assumed to be *any* method.
        /// </summary>
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// Required: Need to know what type of response we will return.
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; set; }

        /// <summary>
        /// Optional: If not provided, then assumed to be *no* content.
        /// </summary>
        public HttpContent HttpContent
        {
            get { return _httpContent; }
            set
            {
                _httpContent = value;
                _httpContentSerialized = _httpContent?.ReadAsStringAsync().Result ?? DefaultValue;
            }
        }

        // Note: I'm using reflection to set the value in here because I want this value to be _read-only_.
        //       Secondly, this occurs during a UNIT TEST, so I consider the expensive reflection costs to be
        //       acceptable in this situation.
        public int NumberOfTimesCalled { get; private set; }

        public override string ToString()
        {
            var httpMethodText = HttpMethod?.ToString() ?? DefaultValue;
            return
                $"{httpMethodText} {RequestUri}{(HttpContent != null ? $" body/content: {_httpContentSerialized}" : "")}";
        }
    }
}
