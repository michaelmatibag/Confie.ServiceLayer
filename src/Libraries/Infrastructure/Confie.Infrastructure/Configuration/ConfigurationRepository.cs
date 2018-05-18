using System;
using System.Configuration;
using Confie.Infrastructure.Exceptions;

namespace Confie.Infrastructure.Configuration
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public T GetConfigurationValue<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (value == null)
            {
                throw new ApplicationConfigurationException($"No configuration setting found for key {key}.");
            }

            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}