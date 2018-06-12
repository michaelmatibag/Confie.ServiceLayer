using Config.Net;

namespace Confie.Infrastructure.UnitTests.Configuration
{
    public interface ITestConfiguration
    {
        [Option(Alias = "Configuration.TestKey")]
        string ConfigurationTest { get; }

        [Option(Alias = "FileHandling.TestKey")]
        string FileHandlingTest { get; }
    }
}