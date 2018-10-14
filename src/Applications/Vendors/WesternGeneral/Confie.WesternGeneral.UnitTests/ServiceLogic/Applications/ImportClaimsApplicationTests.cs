using Autofac;
using Confie.Infrastructure.Application;
using Confie.Infrastructure.Configuration;
using Confie.Infrastructure.FileHandling;
using Confie.Infrastructure.FileRepositories;
using Confie.WesternGeneral.ClaimsRepository;
using Confie.WesternGeneral.Console.DependencyResolution;
using Confie.WesternGeneral.ServiceLogic.Applications;
using Confie.WesternGeneral.ServiceLogic.Configuration;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Confie.WesternGeneral.UnitTests.ServiceLogic.Applications
{
    [TestFixture]
    public class ImportClaimsApplicationTests
    {
        private IConfigurationRepository _configurationRepository;
        private ImportClaimsConfiguration _importClaimsConfiguration;
        private IFileRepository _fileRepository;
        private IFileHandling _fileHandling;
        private IClaimsRepository _claimsRepository;

        [Test]
        public void ImportClaimsApplication_Resolves()
        {
            //Arrange
            var container = ContainerConfiguration.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                //Act
                var application = scope.Resolve<IApplication>();

                //Assert
                application.ShouldNotBeNull();
                application.ShouldBeOfType<ImportClaimsApplication>();
            }
        }

        [Test]
        public void ImportClaimsApplication_Runs()
        {
            //Arrange
            var application = BuildImportClaimsApplication();

            //Act
            application.Run();

            //Assert
            _configurationRepository.VerifyAllExpectations();
            _fileRepository.AssertWasCalled(x => x.CopyFile("TestSource", "TestDestination"));
            _fileHandling.AssertWasCalled(x => x.ReadFile<Claim>(@"TestDestination\TestDestination"));
            _claimsRepository.AssertWasCalled(x => x.SaveClaims(null));
        }

        private ImportClaimsApplication BuildImportClaimsApplication()
        {
            _configurationRepository = MockRepository.GenerateMock<IConfigurationRepository>();

            _configurationRepository.Stub(x => x.GetConfigurationValue<string>("Confie.WesternGeneral.ServiceLogic.ImportClaimsApplication.Source")).Return("TestSource");
            _configurationRepository.Stub(x => x.GetConfigurationValue<string>("Confie.WesternGeneral.ServiceLogic.ImportClaimsApplication.Destination")).Return("TestDestination");

            _importClaimsConfiguration = new ImportClaimsConfiguration(_configurationRepository);
            _fileRepository = MockRepository.GenerateMock<IFileRepository>();
            _fileHandling = MockRepository.GenerateMock<IFileHandling>();
            _claimsRepository = MockRepository.GenerateMock<IClaimsRepository>();

            return new ImportClaimsApplication(_importClaimsConfiguration, _fileRepository, _fileHandling, _claimsRepository);
        }
    }
}