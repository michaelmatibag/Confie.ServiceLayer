using System.Data;
using System.Data.SqlClient;
using Confie.Infrastructure.Configuration;
using Confie.Infrastructure.Logging;
using Dapper;

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
            using (var dbConnection = GetLoggingConnection())
            {
                dbConnection.Execute("dbo.InsertLogMessage",
                    new
                    {
                        logMessage.CorrelationId,
                        logMessage.LogTimestamp,
                        logMessage.LogTypeId,
                        logMessage.IpAddress.IpAddressId,
                        logMessage.Executable.ExecutableId,
                        logMessage.LevelId,
                        logMessage.LogMessage,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void LogWebRequest(WebRequestLogEntry webRequest)
        {
            using (var dbConnection = GetLoggingConnection())
            {
                dbConnection.Execute("dbo.InsertWebRequest",
                    new
                    {
                        webRequest.CorrelationId,
                        webRequest.LogTimestamp,
                        webRequest.LogTypeId,
                        webRequest.IpAddress.IpAddressId,
                        webRequest.Executable.ExecutableId,
                        webRequest.RequestUrl.RequestUrlId,
                        webRequest.RequestHttpVerbId,
                        webRequest.RequestTimestamp,
                        RequesterIPAddressId = webRequest.RequesterIpAddress.IpAddressId,
                        RequesterExecutableId = webRequest.RequesterExecutable?.ExecutableId,
                        webRequest.ResponseTimestamp,
                        webRequest.ResponseHttpStatusCode,
                        webRequest.Request,
                        webRequest.Response,
                        webRequest.ResponseIsCached
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Executable GetWithAddExecutable(Executable executable)
        {
            using (var dbConnection = GetLoggingConnection())
            {
                return dbConnection.QuerySingleOrDefault<Executable>("dbo.Executable_GetWithAdd",
                    new
                    {
                        executable.ExecutableName,
                        executable.ExecutableTypeId,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public RequestUrl GetWithAddRequestUrl(RequestUrl requestUrl)
        {
            using (var dbConnection = GetLoggingConnection())
            {
                return dbConnection.QuerySingleOrDefault<RequestUrl>("dbo.RequestUrl_GetWithAdd",
                    new
                    {
                        RequestUrl = requestUrl.Url,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IpAddress GetWithAddIpAddress(IpAddress ipAddress)
        {
            using (var dbConnection = GetLoggingConnection())
            {
                return dbConnection.QuerySingleOrDefault<IpAddress>("dbo.IPAddress_GetWithAdd",
                    new
                    {
                        IPAddress = ipAddress.Address,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        private SqlConnection GetLoggingConnection()
        {
            return new SqlConnection(_configurationRepository.GetConnectionString(DatabaseCatalog.Logging));
        }
    }
}