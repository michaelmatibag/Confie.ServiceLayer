using System.Collections.Generic;
using Confie.Infrastructure.Logging;
using Confie.Infrastructure.Web;
using NUnit.Framework;
using Shouldly;

namespace Confie.Infrastructure.UnitTests.Web
{
    [TestFixture]
    public class WebResponseTests
    {
        private WebResponse<WebRequestLogRequest> _response;

        [SetUp]
        public void Setup()
        {
            _response = BuildWebResponse();
        }

        [Test]
        public void WebResponse_HasWorking_RequestGetAndSet()
        {
            //Assert
            _response.Request.ShouldNotBeNull();
            _response.Request.ShouldBeOfType<WebRequestLogRequest>();
            _response.Request.WebRequest.Response.ShouldBe("TestResponse");
        }

        [Test]
        public void WebResponse_HasWorking_ErrorsGetAndSet()
        {
            //Act
            _response = AddErrorsToWebResponse(_response);

            //Assert
            _response.Errors.ShouldNotBeNull();
            _response.Errors.ShouldHaveSingleItem();
            _response.Errors[0] = "TestError";
        }

        [Test]
        public void HasErrors_ReturnsFalse_When_WebResponseErrorsIsNull()
        {
            //Assert
            _response.HasErrors.ShouldBeFalse();
        }

        [Test]
        public void HasErrors_ReturnsFalse_When_WebResponseErrorsIsEmpty()
        {
            //Act
            _response.Errors = new List<string>();

            //Assert
            _response.HasErrors.ShouldBeFalse();
        }

        [Test]
        public void HasErrors_ReturnsTrue_When_WebResponseErrorsIsNotNull()
        {
            //Act
            _response = AddErrorsToWebResponse(_response);

            //Assert
            _response.HasErrors.ShouldBeTrue();
        }

        private static WebResponse<WebRequestLogRequest> BuildWebResponse()
        {
            return new WebResponse<WebRequestLogRequest>
            {
                Request = new WebRequestLogRequest
                {
                    WebRequest = new WebRequestLogEntry
                    {
                        Response = "TestResponse"
                    }
                }
            };
        }

        private static WebResponse<WebRequestLogRequest> AddErrorsToWebResponse(WebResponse<WebRequestLogRequest> input)
        {
            input.Errors = new List<string>
            {
                "TestError"
            };

            return input;
        }
    }
}