namespace Confie.Infrastructure.FileRepositories
{
    public interface IFileSystemRepositoryConfiguration
    {
        bool Overwrite { get; }
    }
}