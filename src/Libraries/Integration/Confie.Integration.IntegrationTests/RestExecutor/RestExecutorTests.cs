using System.Collections.Generic;
using Confie.Infrastructure.Configuration;
using Confie.Integration.RestExecutor;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Confie.Integration.IntegrationTests.RestExecutor
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
        public void GetString_Executes_RestApi(string restApi, string resource, string expectedResponse)
        {
            //Arrange
            _configuration.Stub(x => x.BuildFromAppConfiguration<IRestExecutorConfiguration>().RestApi).Return(restApi);

            var restExecutor = new Integration.RestExecutor.RestExecutor(_configuration);

            //Act
            var result = restExecutor.Get(resource);

            //Assert
            result.ShouldContain(expectedResponse);
        }

        [Test]
        public void GetPosts_Executes_RestApi()
        {
            //Arrange
            _configuration.Stub(x => x.BuildFromAppConfiguration<IRestExecutorConfiguration>().RestApi).Return("https://jsonplaceholder.typicode.com");

            var restExecutor = new Integration.RestExecutor.RestExecutor(_configuration);

            //Act
            var result = restExecutor.Get<List<Post>>("posts");

            //Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(100);
            result[0].Title.ShouldBe("sunt aut facere repellat provident occaecati excepturi optio reprehenderit");
        }
    }
}