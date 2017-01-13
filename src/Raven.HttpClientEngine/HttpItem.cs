using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.HttpClientEngine
{
    public class HttpItem
    {
        /// <summary>
        /// 基础链接
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// 相对链接
        /// </summary>
        public string RelativeLink { get; set; }

        /// <summary>
        /// 请求头
        /// </summary>
        public string RequestHeader { get; set; }

        /// <summary>
        /// 请求正文
        /// </summary>
        public string RequestBody { get; set; }

        /// <summary>
        /// 响应头
        /// </summary>
        public string ResponseHeader { get; set; }

        /// <summary>
        /// 响应正文
        /// </summary>
        public string ResponseBody { get; set; }
    }
}
