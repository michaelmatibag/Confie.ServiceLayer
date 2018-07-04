using System.Data.SqlClient;
using Confie.Infrastructure.Configuration;
using Confie.Infrastructure.Logging;

namespace Confie.Logging.ServiceLogic.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IConfigurationRepository _configurationRepository;

        public LogRepository(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public void LogMessage(LogMessageLogEntry logMessage)
        {
            throw new System.NotImplementedException();
        }

        public void LogWebRequest(WebRequestLogEntry webRequest)
        {
            throw new System.NotImplementedException();
        }

        public Executable GetWithAddExecutable(Executable execuatble)
        {
            throw new System.NotImplementedException();
        }

        public RequestUrl GetWithAddRequestUrl(RequestUrl requestUrl)
        {
            throw new System.NotImplementedException();
        }

        public IpAddress GetWithAddIpAddress(IpAddress ipAddress)
        {
            throw new System.NotImplementedException();
        }

        private SqlConnection GetLoggingConnection()
        {
            return new SqlConnection(_configurationRepository.GetConnectionString(DatabaseCatalog.Logging));
        }
    }
}