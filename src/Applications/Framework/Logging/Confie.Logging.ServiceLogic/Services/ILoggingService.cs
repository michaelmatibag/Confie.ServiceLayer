using Confie.Infrastructure.Logging;

namespace Confie.Logging.ServiceLogic.Services
{
    public interface ILoggingService
    {
        LogMessageResponse LogMessage(LogMessageRequest request);
        WebRequestLogResponse LogWebResponse(WebRequestLogRequest request);
    }
}