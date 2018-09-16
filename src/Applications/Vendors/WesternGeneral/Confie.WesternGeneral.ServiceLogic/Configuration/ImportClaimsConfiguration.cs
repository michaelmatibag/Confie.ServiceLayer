using System;
using System.Linq;
using Confie.Infrastructure.Configuration;

namespace Confie.WesternGeneral.ServiceLogic.Configuration
{
    public class ImportClaimsConfiguration
    {
        public string Source { get; }
        public string Destination { get; }
        public string ClaimsFile { get; }

        public ImportClaimsConfiguration(IConfigurationRepository configurationRepository)
        {
            Source = configurationRepository.GetConfigurationValue<string>("Confie.WesternGeneral.ServiceLogic.ImportClaimsApplication.Source");
            Destination = configurationRepository.GetConfigurationValue<string>("Confie.WesternGeneral.ServiceLogic.ImportClaimsApplication.Destination");
            ClaimsFile = Destination.Split(new[] {@"\", "/"}, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
        }
    }
}