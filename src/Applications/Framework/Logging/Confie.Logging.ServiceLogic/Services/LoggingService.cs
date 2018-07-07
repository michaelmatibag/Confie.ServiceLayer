using System;
using Confie.Infrastructure.DependencyResolution;
using Confie.Infrastructure.Logging;
using Confie.Logging.ServiceLogic.Repositories;
using LazyCache;

namespace Confie.Logging.ServiceLogic.Services
{
    [Injectable]
    public class LoggingService : ILoggingService
    {
        private readonly ILogRepository _logRepository;
        private readonly IAppCache _appCache;

        public LoggingService(ILogRepository logRepository, IAppCache appCache)
        {
            _logRepository = logRepository;
            _appCache = appCache;
        }

        public LogMessageResponse LogMessage(LogMessageRequest request)
        {
            var response = new LogMessageResponse
            {
                Request = request
            };

            GetLogMessageLookupValues(request.LogMessage);

            _logRepository.LogMessage(request.LogMessage);

            return response;
        }

        public WebRequestLogResponse LogWebRequest(WebRequestLogRequest request)
        {
            var response = new WebRequestLogResponse()
            {
                Request = request,
            };

            GetWebRequestLookupValues(request.WebRequest);

            _logRepository.LogWebRequest(request.WebRequest);

            return response;
        }

        private void GetLogMessageLookupValues(LogEntry logEntry)
        {
            logEntry.IpAddress = GetIpAddress(logEntry.IpAddress);
            logEntry.Executable = GetExecutable(logEntry.Executable);
        }

        private void GetWebRequestLookupValues(WebRequestLogEntry entry)
        {
            entry.IpAddress = GetIpAddress(entry.IpAddress);
            entry.Executable = GetExecutable(entry.Executable);
            entry.RequestUrl = GetRequestUrl(entry.RequestUrl);
            entry.RequesterExecutable = GetExecutable(entry.RequesterExecutable);
            entry.RequesterIpAddress = GetIpAddress(entry.RequesterIpAddress);
        }

        private IpAddress GetIpAddress(IpAddress ipAddress)
        {
            var ipAddressCacheKey = $"LoggingService-IPAddresses-{ipAddress.Address}";

            return _appCache.GetOrAdd(ipAddressCacheKey,
                () => _logRepository.GetWithAddIpAddress(ipAddress),
                new TimeSpan(0, 10, 0));
        }

        private Executable GetExecutable(Executable executable)
        {
            if (executable == null) { return null; }

            var executableCacheKey = $"LoggingService-Executables-{executable.ExecutableName}-{executable.ExecutableTypeId}";

            return _appCache.GetOrAdd(executableCacheKey,
                () => _logRepository.GetWithAddExecutable(executable),
                new TimeSpan(0, 10, 0));
        }

        private RequestUrl GetRequestUrl(RequestUrl requestUrl)
        {
            var requestUrlCacheKey = $"LoggingService-RequestUrls-{requestUrl.Url}";

            return _appCache.GetOrAdd(requestUrlCacheKey,
                () => _logRepository.GetWithAddRequestUrl(requestUrl),
                new TimeSpan(0, 10, 0));
        }
    }
}