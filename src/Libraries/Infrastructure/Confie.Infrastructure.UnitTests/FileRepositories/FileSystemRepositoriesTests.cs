using System.IO.Abstractions.TestingHelpers;
using Confie.Infrastructure.Configuration;
using Confie.Infrastructure.Exceptions;
using Confie.Infrastructure.FileRepositories;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Confie.Infrastructure.UnitTests.FileRepositories
{
    [TestFixture]
    public class FileSystemRepositoriesTests
    {
        private MockFileSystem _fileSystem;
        private IConfigurationRepository _configurationRepository;

        [SetUp]
        public void Setup()
        {
            _fileSystem = new MockFileSystem();
            _configurationRepository = MockRepository.GenerateStub<IConfigurationRepository>();
        }

        [Test]
        public void CopyFile_ThrowsException_IfSourceIsDirectory()
        {
            //Arrange
            const string source = @"C:\source";
            const string destination = @"C:\destination";

            _fileSystem.AddDirectory(source);

            var fileSystemRepository = GetFileSystemRepository();

            //Act & Assert
            Should.Throw<FileOperationException>(() => { fileSystemRepository.CopyFile(source, destination); }).Message
                .ShouldBe($"The source file {source} is a directory and is invalid.");
        }

        [Test]
        public void CopyFile_OverwritesFile_OnTrueOverwriteConfiguration()
        {
            //Arrange
            const string source = @"C:\source\test.dat";
            const string destination = @"C:\destination\test.dat";

            _fileSystem.AddFile(source, MockFileData.NullObject);
            _fileSystem.AddFile(destination, MockFileData.NullObject);
            _configurationRepository.Stub(x => x.GetConfigurationValue<bool>("FileSystemRepository.Overwrite")).Return(true);

            var fileSystemRepository = GetFileSystemRepository();

            //Act & Assert
            Should.NotThrow(() => { fileSystemRepository.CopyFile(source, destination); });
            _fileSystem.FileExists(destination).ShouldBe(true);
        }

        private FileSystemRepository GetFileSystemRepository()
        {
            return new FileSystemRepository(_fileSystem, _configurationRepository);
        }
    }
}