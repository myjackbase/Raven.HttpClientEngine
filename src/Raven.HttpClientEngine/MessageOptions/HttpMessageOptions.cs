using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.HttpClientEngine.MessageOptions
{
    public class HttpMessageOptions
    {
        public List<KeyValuePair<string, string>> Headers { get; set; }

        public string Body { get; set; }

        public HttpMessageOptions()
        {
            Headers = new List<KeyValuePair<string, string>>();
        }
    }
}
