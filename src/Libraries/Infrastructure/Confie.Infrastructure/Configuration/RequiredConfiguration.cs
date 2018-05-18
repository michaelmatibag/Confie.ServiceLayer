using System;
using System.Collections.Generic;
using System.Configuration;
using Confie.Infrastructure.Exceptions;

namespace Confie.Infrastructure.Configuration
{
    public abstract class RequiredConfiguration
    {
        public void ValidateRequiredConfiguration(Dictionary<string, Type> requiredConfiguration)
        {
            foreach (var keyValuePair in requiredConfiguration)
            {
                var value = ConfigurationManager.AppSettings[keyValuePair.Key];

                if (value == null)
                {
                    throw new ApplicationConfigurationException($"Required configuration key {keyValuePair.Key} not found; check your configuration.");
                }

                try
                {
                    var convertedValue = Convert.ChangeType(value, keyValuePair.Value);
                }
                catch
                {
                    throw new ApplicationConfigurationException($"Error occurred while converting value {value} of key {keyValuePair.Key} to type {keyValuePair.Value.Name}; check your configuration value.");
                }
            }
        }
    }
}