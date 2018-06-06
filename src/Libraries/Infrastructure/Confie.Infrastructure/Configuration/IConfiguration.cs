namespace Confie.Infrastructure.Configuration
{
    public interface IConfiguration
    {
        T BuildFromAppConfiguration<T>() where T : class;
    }
}