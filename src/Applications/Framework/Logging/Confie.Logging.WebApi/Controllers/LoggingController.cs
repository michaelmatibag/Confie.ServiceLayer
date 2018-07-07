using Confie.Infrastructure.Logging;
using Confie.Logging.ServiceLogic.Services;
using System.Web.Http;
using System.Web.Http.Description;

namespace Confie.Logging.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class LoggingController : ApiController
    {
        private readonly ILoggingService _loggingService;

        public LoggingController(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        [Route("v1/log/message")]
        [HttpPost]
        [ResponseType(typeof(LogMessageResponse))]
        public IHttpActionResult LogMessageV1(LogMessageRequest request)
        {
            if (!request.IsValid)
            {
                return BadRequest("Invalid request provided, please check your request body.");
            }

            var response = _loggingService.LogMessage(request);

            return Ok(response);
        }

        [Route("v1/log/webrequest")]
        [HttpPost]
        [ResponseType(typeof(WebRequestLogResponse))]
        public IHttpActionResult LogWebRequestV1(WebRequestLogRequest request)
        {
            if (!request.IsValid)
            {
                return BadRequest("Invalid request provided, please check your request body.");
            }

            var response = _loggingService.LogWebRequest(request);

            return Ok(response);
        }
    }
}