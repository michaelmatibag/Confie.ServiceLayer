namespace Confie.Infrastructure.FileRepositories
{
    public interface IFileRepository
    {
        void CopyFile(string source, string destination);
    }
}