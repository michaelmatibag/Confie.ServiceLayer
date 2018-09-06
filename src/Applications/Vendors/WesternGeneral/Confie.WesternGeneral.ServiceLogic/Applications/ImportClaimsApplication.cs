using System;
using System.IO;
using System.Linq;
using Confie.Infrastructure.Application;
using Confie.Infrastructure.FileHandling;
using Confie.Infrastructure.FileRepositories;
using Confie.WesternGeneral.ServiceLogic.Configuration;

namespace Confie.WesternGeneral.ServiceLogic.Applications
{
    public class ImportClaimsApplication : IApplication
    {
        private readonly ImportClaimsConfiguration _importClaimsConfiguration;
        private readonly IFileRepository _fileRepository;
        private readonly IFileHandling _fileHandling;

        public ImportClaimsApplication(ImportClaimsConfiguration importClaimsConfiguration, IFileRepository fileRepository, IFileHandling fileHandling)
        {
            _importClaimsConfiguration = importClaimsConfiguration;
            _fileRepository = fileRepository;
            _fileHandling = fileHandling;
        }

        public void Run()
        {
            _fileRepository.CopyFile(_importClaimsConfiguration.Source, _importClaimsConfiguration.Destination);

            var file = Path.Combine(_importClaimsConfiguration.Destination, _importClaimsConfiguration.ClaimsFile);
            var claims = _fileHandling.ReadFile<Claim>(file);
        }
    }
}