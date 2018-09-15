using System.IO;
using Confie.Infrastructure.Application;
using Confie.Infrastructure.FileHandling;
using Confie.Infrastructure.FileRepositories;
using Confie.WesternGeneral.ClaimsRepository;
using Confie.WesternGeneral.ServiceLogic.Configuration;

namespace Confie.WesternGeneral.ServiceLogic.Applications
{
    public class ImportClaimsApplication : IApplication
    {
        private readonly ImportClaimsConfiguration _importClaimsConfiguration;
        private readonly IFileRepository _fileRepository;
        private readonly IFileHandling _fileHandling;
        private readonly IClaimsRepository _claimsRepository;

        public ImportClaimsApplication(ImportClaimsConfiguration importClaimsConfiguration, IFileRepository fileRepository, IFileHandling fileHandling, IClaimsRepository claimsRepository)
        {
            _importClaimsConfiguration = importClaimsConfiguration;
            _fileRepository = fileRepository;
            _fileHandling = fileHandling;
            _claimsRepository = claimsRepository;
        }

        public void Run()
        {
            _fileRepository.CopyFile(_importClaimsConfiguration.Source, _importClaimsConfiguration.Destination);

            var file = Path.Combine(_importClaimsConfiguration.Destination, _importClaimsConfiguration.ClaimsFile);
            var claims = _fileHandling.ReadFile<Claim>(file);

            _claimsRepository.SaveClaims(claims);
        }
    }
}