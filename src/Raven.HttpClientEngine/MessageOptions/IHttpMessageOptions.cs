using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.HttpClientEngine.MessageOptions
{
    public interface IHttpMessageOptions
    {
        string RequestUri { get; set; }

        string RequestHeader { get; set; }

        string RequestBody { get; set; }

        //string RequestEncoding { get; set; }

        HttpMethod HttpMethod { get; set; }

        string ResponseHeader { get; set; }

        string ResponseBody { get; set; }

        //string ResponseEncoding { get; set; }
    }
}
