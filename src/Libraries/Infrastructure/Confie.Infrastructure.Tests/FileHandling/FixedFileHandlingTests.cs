using System.IO;
using Confie.Infrastructure.FileHandling;
using Confie.WesternGeneral.FlatFile;
using NUnit.Framework;
using Shouldly;

namespace Confie.Infrastructure.Tests.FileHandling
{
    [TestFixture]
    public class FixedFileHandlingTests
    {
        private IFileHandling _fileHandling;

        [SetUp]
        public void SetUp()
        {
            _fileHandling = new FixedFileHandling();
        }

        [Test]
        public void ClaimReadClaims()
        {
            //Arrange
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"FileHandling\FixedFiles\Claim.txt");

            //Act
            var result = _fileHandling.ReadFile<Claim>(path);

            //Assert
            result.ShouldNotBeNull();
        }
    }
}
