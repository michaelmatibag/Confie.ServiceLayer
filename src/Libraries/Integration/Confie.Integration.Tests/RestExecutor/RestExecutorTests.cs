using Confie.Infrastructure.Configuration;
using Confie.Integration.RestExecutor;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Confie.Integration.Tests.RestExecutor
{
    [TestFixture]
    public class RestExecutorTests
    {
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            _configuration = MockRepository.GenerateMock<IConfiguration>();
        }

        [TestCase("http://loripsum.net/api", "headers", "Lorem ipsum dolor sit amet")]
        [TestCase("http://jsonplaceholder.typicode.com", "posts/1", "sunt aut facere repellat provident occaecati excepturi optio reprehenderit")]
        public void Execute_Executes_RestApi(string restApi, string request, string expectedResponse)
        {
            //Arrange
            _configuration.Stub(x => x.BuildFromAppConfiguration<IRestExecutorConfiguration>().RestApi).Return(restApi);

            var restExecutor = new Integration.RestExecutor.RestExecutor(_configuration);

            //Act
            var result = restExecutor.Execute(request);

            //Assert
            result.ShouldContain(expectedResponse);
        }
    }
}