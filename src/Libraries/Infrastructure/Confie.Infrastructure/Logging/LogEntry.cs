using System;

namespace Confie.Infrastructure.Logging
{
    public class LogEntry
    {
        public int? LogId { get; set; }
        public Guid CorrelationId { get; set; }
        public DateTime LogTimestamp { get; set; }
        public LogType LogTypeId { get; set; }
        public IpAddress IpAddress { get; set; }
        public Executable Executable { get; set; }
    }
}