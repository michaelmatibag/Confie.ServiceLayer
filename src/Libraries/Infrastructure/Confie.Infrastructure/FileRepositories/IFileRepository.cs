namespace Confie.Infrastructure.FileRepositories
{
    public interface IFileRepository
    {
        bool CopyFile(string path);
    }
}