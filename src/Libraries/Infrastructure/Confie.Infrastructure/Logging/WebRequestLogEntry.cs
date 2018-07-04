using System;
using System.Net;

namespace Confie.Infrastructure.Logging
{
    public class WebRequestLogEntry : LogEntry
    {
        public RequestUrl RequestUrl { get; set; }
        public HttpVerb RequestHttpVerbId { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public IpAddress RequesterIpAddress { get; set; }
        public Executable RequesterExecutable { get; set; }
        public DateTime ResponseTimestamp { get; set; }
        public HttpStatusCode ResponseHttpStatusCode { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public bool ResponseIsCached { get; set; }
    }
}