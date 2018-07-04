using System;
using Confie.Infrastructure.Web;

namespace Confie.Infrastructure.Logging
{
    public class LogMessageRequest : WebRequest
    {
        public LogMessageLogEntry LogMessage { get; set; }

        public override bool IsValid => LogMessage != null
                                        && LogMessage.CorrelationId != default(Guid)
                                        && LogMessage.LogTypeId != LogType.Unknown
                                        && LogMessage.IpAddress != null
                                        && !string.IsNullOrWhiteSpace(LogMessage.IpAddress.Address)
                                        && LogMessage.Executable != null
                                        && !string.IsNullOrWhiteSpace(LogMessage.Executable.ExecutableName)
                                        && LogMessage.Executable.ExecutableTypeId != ExecutableType.Unknown
                                        && LogMessage.LevelId != Level.Unknown
                                        && !string.IsNullOrWhiteSpace(LogMessage.LogMessage);
    }
}