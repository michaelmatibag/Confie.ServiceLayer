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
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new FileOperationException("The source was not specified.");
            }

            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new FileOperationException("The destination was not specified.");
            }

            if (!_fileSystem.File.Exists(source))
            {
                throw new FileOperationException($"The source file {source} does not exist");
            }

            if (_fileSystem.File.GetAttributes(source).HasFlag(FileAttributes.Directory))
            {
                throw new FileOperationException($"The source file {source} is a directory and is invalid.");
            }

            var fullDestination = _fileSystem.Path.Combine(destination, _fileSystem.Path.GetFileName(source));

            if (!_fileSystem.Directory.Exists(destination))
            {
                _fileSystem.Directory.CreateDirectory(destination);

                _fileSystem.File.Copy(source, fullDestination, true);
            }
            else
            {
                var overwrite = _configurationRepository.GetConfigurationValue<bool>("FileSystemRepository.Overwrite");

                if (overwrite)
                {
                    _fileSystem.File.Copy(source, fullDestination, true);
                }
                else
                {
                    if (!_fileSystem.File.Exists(fullDestination))
                    {
                        _fileSystem.File.Copy(source, fullDestination);
                    }
                }
            }
        }
    }
}