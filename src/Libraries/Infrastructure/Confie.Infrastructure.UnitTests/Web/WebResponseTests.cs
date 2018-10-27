using System;
using System.Collections.Generic;
using System.Net;
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
        private static DateTime _timestamp;

        [SetUp]
        public void Setup()
        {
            _timestamp = DateTime.Now;
            _response = BuildWebResponse();
        }

        [Test]
        public void WebResponse_HasWorking_RequestGetAndSet()
        {
            //Assert
            _response.Request.ShouldNotBeNull();
            _response.Request.ShouldBeOfType<WebRequestLogRequest>();
            _response.Request.WebRequest.RequestUrl.ShouldNotBeNull();
            _response.Request.WebRequest.RequestUrl.RequestUrlId.ShouldBe(8);
            _response.Request.WebRequest.RequestUrl.Url.ShouldBe("TestUrl");
            _response.Request.WebRequest.RequestHttpVerbId.ShouldBe(HttpVerb.PUT);
            _response.Request.WebRequest.RequestTimestamp.ShouldBe(_timestamp);
            _response.Request.WebRequest.RequesterIpAddress.ShouldNotBeNull();
            _response.Request.WebRequest.RequesterIpAddress.Address.ShouldBe("TestAddress");
            _response.Request.WebRequest.RequesterIpAddress.IpAddressId.ShouldBe(8);
            _response.Request.WebRequest.RequesterExecutable.ShouldNotBeNull();
            _response.Request.WebRequest.RequesterExecutable.ExecutableId.ShouldBe(8);
            _response.Request.WebRequest.RequesterExecutable.ExecutableName.ShouldBe("TestExecutableName");
            _response.Request.WebRequest.RequesterExecutable.ExecutableTypeId.ShouldBe(ExecutableType.ConsoleApplication);
            _response.Request.WebRequest.ResponseTimestamp.ShouldBe(_timestamp);
            _response.Request.WebRequest.ResponseHttpStatusCode.ShouldBe(HttpStatusCode.OK);
            _response.Request.WebRequest.Request.ShouldBe("TestRequest");
            _response.Request.WebRequest.Response.ShouldBe("TestResponse");
            _response.Request.WebRequest.ResponseIsCached.ShouldBe(true);
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
                        RequestUrl = new RequestUrl
                        {
                            RequestUrlId = 8,
                            Url = "TestUrl"
                        },
                        RequestHttpVerbId = HttpVerb.PUT,
                        RequestTimestamp = _timestamp,
                        RequesterIpAddress = new IpAddress
                        {
                            Address = "TestAddress",
                            IpAddressId = 8
                        },
                        RequesterExecutable = new Executable
                        {
                            ExecutableId = 8,
                            ExecutableName = "TestExecutableName",
                            ExecutableTypeId = ExecutableType.ConsoleApplication
                        },
                        ResponseTimestamp = _timestamp,
                        ResponseHttpStatusCode = HttpStatusCode.OK,
                        Request = "TestRequest",
                        Response = "TestResponse",
                        ResponseIsCached = true
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