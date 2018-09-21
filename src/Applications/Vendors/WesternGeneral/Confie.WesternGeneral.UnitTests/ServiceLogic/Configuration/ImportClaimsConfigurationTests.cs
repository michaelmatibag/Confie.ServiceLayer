using Confie.Infrastructure.Configuration;
using Confie.WesternGeneral.ServiceLogic.Configuration;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Confie.WesternGeneral.UnitTests.ServiceLogic.Configuration
{
    [TestFixture]
    public class ImportClaimsConfigurationTests
    {
        private IConfigurationRepository _configurationRepository;

        [SetUp]
        public void Setup()
        {
            _configurationRepository = MockRepository.GenerateMock<IConfigurationRepository>();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("Source")]
        public void ImportClaimsConfiguration_Configures_Source(string testValue)
        {
            //Arrange
            _configurationRepository
                .Stub(x => x.GetConfigurationValue<string>("Confie.WesternGeneral.ServiceLogic.ImportClaimsApplication.Source"))
                .Return(testValue);
            _configurationRepository
                .Stub(x => x.GetConfigurationValue<string>("Confie.WesternGeneral.ServiceLogic.ImportClaimsApplication.Destination"))
                .Return(string.Empty);

            //Act
            var configuration = new ImportClaimsConfiguration(_configurationRepository);

            //Assert
            configuration.Source.ShouldBe(testValue);
        }

        [Test]
        public void ImportClaimsConfiguration_Returns_CorrectConfiguration()
        {
            //Arrange
            _configurationRepository
                .Stub(x => x.GetConfigurationValue<string>("Confie.WesternGeneral.ServiceLogic.ImportClaimsApplication.Source"))
                .Return("Source");
            _configurationRepository
                .Stub(x => x.GetConfigurationValue<string>("Confie.WesternGeneral.ServiceLogic.ImportClaimsApplication.Destination"))
                .Return("Some/Destination/Of/ClaimsFile");

            //Act
            var configuration = new ImportClaimsConfiguration(_configurationRepository);

            //Assert
            configuration.Source.ShouldBe("Source");
            configuration.Destination.ShouldBe("Some/Destination/Of/ClaimsFile");
            configuration.ClaimsFile.ShouldBe("ClaimsFile");
        }
    }
}