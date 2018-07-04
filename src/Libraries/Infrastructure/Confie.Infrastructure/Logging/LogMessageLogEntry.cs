namespace Confie.Infrastructure.Logging
{
    public class LogMessageLogEntry : LogEntry
    {
        public Level LevelId { get; set; }
        public string LogMessage { get; set; }
    }
}