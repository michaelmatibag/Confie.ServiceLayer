using System.IO;
using Confie.Infrastructure.DependencyResolution;
using Confie.Infrastructure.Exceptions;

namespace Confie.Infrastructure.FileRepositories
{
    [Injectable]
    public class FileSystemRepository : IFileRepository
    {
        private readonly FileSystemRepositoryConfiguration _fileSystemRepositoryConfiguration;

        public FileSystemRepository(FileSystemRepositoryConfiguration fileSystemRepositoryConfiguration)
        {
            _fileSystemRepositoryConfiguration = fileSystemRepositoryConfiguration;
        }

        public bool CopyFile(string source, string destination)
        {
            try
            {
                File.Copy(source, destination, _fileSystemRepositoryConfiguration.Overwrite);

                return true;
            }
            catch
            {
                throw new FileOperationException($"The file {source} could not be copied to {destination}.");
            }
        }
    }
}