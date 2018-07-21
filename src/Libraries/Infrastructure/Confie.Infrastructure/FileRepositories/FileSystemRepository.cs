using System.IO;
using System.IO.Abstractions;
using Confie.Infrastructure.Configuration;
using Confie.Infrastructure.DependencyResolution;
using Confie.Infrastructure.Exceptions;

namespace Confie.Infrastructure.FileRepositories
{
    [Injectable]
    public class FileSystemRepository : IFileRepository
    {
        private readonly IFileSystem _fileSystem;
        private readonly IConfigurationRepository _configurationRepository;

        public FileSystemRepository(IFileSystem fileSystem, IConfigurationRepository configurationRepository)
        {
            _fileSystem = fileSystem;
            _configurationRepository = configurationRepository;
        }

        public void CopyFile(string source, string destination)
        {
            if (_fileSystem.File.GetAttributes(source).HasFlag(FileAttributes.Directory))
            {
                throw new FileOperationException($"The source file {source} is a directory and is invalid.");
            }

            if (_fileSystem.File.GetAttributes(destination).HasFlag(FileAttributes.Directory))
            {
                if (!_fileSystem.Directory.Exists(destination))
                {
                    _fileSystem.Directory.CreateDirectory(destination);
                }

                var fileName = _fileSystem.Path.GetFileName(source);

                _fileSystem.File.Copy(source, _fileSystem.Path.Combine(destination, fileName));
            }
            else
            {
                var overwrite = _configurationRepository.GetConfigurationValue<bool>("FileSystemRepository.Overwrite");

                if (!_fileSystem.File.Exists(destination) || overwrite)
                {
                    _fileSystem.File.Copy(source, destination, overwrite);
                }
            }
        }
    }
}