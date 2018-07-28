using System.Collections.Generic;
using Confie.Infrastructure.Configuration;
using Confie.Integration.RestExecutor;
using Newtonsoft.Json;
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
            result.Count.ShouldBe(101);
            result[0].Title.ShouldBe("sunt aut facere repellat provident occaecati excepturi optio reprehenderit");
        }

        [Test]
        public void PostPostString_Executes_RestApi()
        {
            //Arrange
            _configuration.Stub(x => x.BuildFromAppConfiguration<IRestExecutorConfiguration>().RestApi).Return("https://jsonplaceholder.typicode.com");

            var restExecutor = new Integration.RestExecutor.RestExecutor(_configuration);
            var request = JsonConvert.SerializeObject(StubPost());

            //Act
            var result = restExecutor.Post("posts", request);

            //Assert
            result.ShouldNotBeNullOrWhiteSpace();
            result.ShouldBe("{\n  \"userId\": 12345,\n  \"id\": 12345,\n  \"title\": \"TestTitle\",\n  \"body\": \"TestBody\"\n}");
        }

        [Test]
        public void PostPostsString_Executes_RestApi()
        {
            //Arrange
            _configuration.Stub(x => x.BuildFromAppConfiguration<IRestExecutorConfiguration>().RestApi).Return("https://jsonplaceholder.typicode.com");

            var restExecutor = new Integration.RestExecutor.RestExecutor(_configuration);
            var request = StubPosts();

            //Act
            var result = restExecutor.Post("posts", request);

            //Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<List<Post>>();
            result.Count.ShouldBe(2);
            result[0].Body.ShouldBe("TestBody1");
            result[0].Id.ShouldBe(11111);
            result[0].Title.ShouldBe("TestTitle1");
            result[0].UserId.ShouldBe(11111);
            result[1].Body.ShouldBe("TestBody2");
            result[1].Id.ShouldBe(22222);
            result[1].Title.ShouldBe("TestTitle2");
            result[1].UserId.ShouldBe(22222);
        }

        [Test]
        public void PostPostObject_Executes_RestApi()
        {
            //Arrange
            _configuration.Stub(x => x.BuildFromAppConfiguration<IRestExecutorConfiguration>().RestApi).Return("https://jsonplaceholder.typicode.com");

            var restExecutor = new Integration.RestExecutor.RestExecutor(_configuration);
            var request = StubPost();

            //Act
            var result = restExecutor.Post("posts", request);

            //Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<Post>();
            result.Body.ShouldBe("TestBody");
            result.Id.ShouldBe(12345);
            result.Title.ShouldBe("TestTitle");
            result.UserId.ShouldBe(12345);
        }

        [Test]
        public void PostPostsObject_Executes_RestApi()
        {
            //Arrange
            _configuration.Stub(x => x.BuildFromAppConfiguration<IRestExecutorConfiguration>().RestApi).Return("https://jsonplaceholder.typicode.com");

            var restExecutor = new Integration.RestExecutor.RestExecutor(_configuration);
            var request = StubPosts();

            //Act
            var result = restExecutor.Post("posts", request);

            //Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<List<Post>>();
            result.Count.ShouldBe(2);
            result[0].Body.ShouldBe("TestBody1");
            result[0].Id.ShouldBe(11111);
            result[0].Title.ShouldBe("TestTitle1");
            result[0].UserId.ShouldBe(11111);
            result[1].Body.ShouldBe("TestBody2");
            result[1].Id.ShouldBe(22222);
            result[1].Title.ShouldBe("TestTitle2");
            result[1].UserId.ShouldBe(22222);
        }

        private static Post StubPost()
        {
            return new Post
            {
                Body = "TestBody",
                Id = 12345,
                Title = "TestTitle",
                UserId = 12345
            };
        }

        private static List<Post> StubPosts()
        {
            return new List<Post>
            {
                new Post
                {
                    Body = "TestBody1",
                    Id = 11111,
                    Title = "TestTitle1",
                    UserId = 11111
                },
                new Post
                {
                    Body = "TestBody2",
                    Id = 22222,
                    Title = "TestTitle2",
                    UserId = 22222
                }
            };
        }
    }
}