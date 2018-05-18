namespace Confie.Infrastructure.Configuration
{
    public interface IConfigurationRepository
    {
        T GetConfigurationValue<T>(string key);
    }
}