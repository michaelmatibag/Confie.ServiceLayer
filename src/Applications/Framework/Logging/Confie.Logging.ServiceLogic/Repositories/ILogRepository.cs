using Confie.Infrastructure.Logging;

namespace Confie.Logging.ServiceLogic.Repositories
{
    public interface ILogRepository
    {
        void LogMessage(LogMessageLogEntry logMessage);
        void LogWebRequest(WebRequestLogEntry webRequest);
        Executable GetWithAddExecutable(Executable execuatble);
        RequestUrl GetWithAddRequestUrl(RequestUrl requestUrl);
        IpAddress GetWithAddIpAddress(IpAddress ipAddress);
    }
}