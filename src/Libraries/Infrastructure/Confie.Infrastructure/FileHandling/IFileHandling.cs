namespace Confie.Infrastructure.FileHandling
{
    public interface IFileHandling
    {
        T[] ReadFile<T>(string path) where T : class;
    }
}