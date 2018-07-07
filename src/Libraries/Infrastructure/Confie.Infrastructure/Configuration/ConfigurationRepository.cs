using System;
using System.Configuration;
using Confie.Infrastructure.DependencyResolution;
using Confie.Infrastructure.Exceptions;

namespace Confie.Infrastructure.Configuration
{
    [Injectable]
    public class ConfigurationRepository : IConfigurationRepository
    {
        public string GetConnectionString(DatabaseCatalog databaseCatalog)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[databaseCatalog.ToString()];

            if (connectionString == null)
            {
                throw new ApplicationConfigurationException($"Requested connection string for {databaseCatalog.ToString()} not found.");
            }

            return connectionString.ConnectionString;
        }

        public T GetConfigurationValue<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (value == null)
            {
                throw new ApplicationConfigurationException($"No config setting found for {key}.");
            }

            var convertedValue = (T) Convert.ChangeType(value, typeof(T));

            return convertedValue;
        }
    }
}