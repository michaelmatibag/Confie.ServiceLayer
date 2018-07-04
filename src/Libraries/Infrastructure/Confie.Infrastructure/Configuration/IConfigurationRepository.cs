namespace Confie.Infrastructure.Configuration
{
    public interface IConfigurationRepository
    {
        string GetConnectionString(DatabaseCatalog databaseCatalog);

        T GetConfigurationValue<T>(string key);
    }
}