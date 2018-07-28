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

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void CopyFile_ThrowsException_WhenSourceIsNullOrWhiteSpace(string input)
        {
            //Arrange
            var fileSystemRepository = GetFileSystemRepository();

            //Act & Assert
            Should.Throw<FileOperationException>(() => { fileSystemRepository.CopyFile(input, null); })
                .Message.ShouldBe("The source was not specified.");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void CopyFile_ThrowsException_WhenDestinationIsNullOrWhiteSpace(string input)
        {
            //Arrange
            const string source = @"C:\source\someFile.dat";
            var fileSystemRepository = GetFileSystemRepository();

            //Act & Assert
            Should.Throw<FileOperationException>(() => { fileSystemRepository.CopyFile(source, input); })
                .Message.ShouldBe("The destination was not specified.");
        }

        [Test]
        public void CopyFile_ThrowsException_WhenSourceDoesNotExist()
        {
            //Arrange
            const string source = @"C:\source\someFile.dat";
            const string destination = @"C:\destination";

            var fileSystemRepository = GetFileSystemRepository();

            //Act & Assert
            Should.Throw<FileOperationException>(() => { fileSystemRepository.CopyFile(source, destination); })
                .Message.ShouldBe($"The source file {source} does not exist");
        }

        [Test]
        public void CopyFile_CopiesFile_OnNonExistingDirectory()
        {
            //Arrange
            const string source = @"C:\source\someFile.dat";
            const string destination = @"C:\destination\";

            _fileSystem.AddFile(source, MockFileData.NullObject);

            var fileSystemRepository = GetFileSystemRepository();

            //Act
            fileSystemRepository.CopyFile(source, destination);

            //Assert
            _fileSystem.Directory.Exists(destination).ShouldBe(true);
            _fileSystem.FileExists($"{destination}someFile.dat").ShouldBe(true);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void CopyFile_CopiesFile_OnExistingDirectory(bool input)
        {
            //Arrange
            const string source = @"C:\source\someFile.dat";
            const string destination = @"C:\destination\";

            _fileSystem.AddFile(source, MockFileData.NullObject);
            _fileSystem.AddDirectory(destination);
            _configurationRepository.Stub(x => x.GetConfigurationValue<bool>("FileSystemRepository.Overwrite")).Return(input);

            var fileSystemRepository = GetFileSystemRepository();

            //Act
            fileSystemRepository.CopyFile(source, destination);
            
            //Assert
            _fileSystem.FileExists($"{destination}someFile.dat").ShouldBe(true);
        }

        private FileSystemRepository GetFileSystemRepository()
        {
            return new FileSystemRepository(_fileSystem, _configurationRepository);
        }
    }
}