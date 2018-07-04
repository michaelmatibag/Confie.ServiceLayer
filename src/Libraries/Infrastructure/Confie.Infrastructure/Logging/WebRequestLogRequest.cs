using System;
using Confie.Infrastructure.Web;

namespace Confie.Infrastructure.Logging
{
    public class WebRequestLogRequest : WebRequest
    {
        public WebRequestLogEntry WebRequest { get; set; }

        public override bool IsValid => WebRequest != null
                                        && WebRequest.CorrelationId != default(Guid)
                                        && WebRequest.LogTypeId != LogType.Unknown
                                        && WebRequest.IpAddress != null
                                        && !string.IsNullOrWhiteSpace(WebRequest.IpAddress.Address)
                                        && WebRequest.Executable != null
                                        && !string.IsNullOrWhiteSpace(WebRequest.Executable.ExecutableName)
                                        && WebRequest.Executable.ExecutableTypeId != ExecutableType.Unknown
                                        && WebRequest.RequestUrl != null
                                        && !string.IsNullOrWhiteSpace(WebRequest.RequestUrl.Url)
                                        && WebRequest.RequestHttpVerbId != HttpVerb.UNKNOWN
                                        && WebRequest.LogTimestamp != default(DateTime)
                                        && WebRequest.RequestTimestamp != default(DateTime)
                                        && WebRequest.RequesterIpAddress != null
                                        && !string.IsNullOrWhiteSpace(WebRequest.RequesterIpAddress.Address)
                                        && WebRequest.ResponseTimestamp != default(DateTime);
    }
}