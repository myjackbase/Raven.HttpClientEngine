﻿using Raven.HttpClientEngine.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.HttpClientEngine.MessageOptions
{
    public class HttpResponseMessageOptions : HttpMessageOptions
    {
        public bool IsTraceLog { get; set; }

        public TraceLogType LogType { get; set; }


    }
}
