using NUnit.Framework;
using Shouldly;

namespace Confie.Infrastructure.Tests.Configuration
{
    [TestFixture]
    public class ConfigurationTests
    {
        [Test]
        public void Configuration_Builds_Configuration()
        {
            //Arrange
            var configuration = new Infrastructure.Configuration.Configuration();

            //Act
            var result = configuration.BuildFromAppConfiguration<ITestConfiguration>();

            //Assert
            result.ConfigurationTest.ShouldBe("Configuration.TestValue");
            result.FileHandlingTest.ShouldBe("FileHandling.TestValue");
        }
    }
}