using FileHelpers;

namespace Confie.Infrastructure.FileHandling
{
    public class FixedFileHandling : IFileHandling
    {
        public T[] ReadFile<T>(string path) where T : class
        {
            var engine = new FixedFileEngine<T>();

            return engine.ReadFile(path);
        }
    }
}