using System.Web.Http;
using Confie.Logging.WebApi.DependencyResolution;

namespace Confie.Logging.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            LoggingServiceLogicFeature.DependencyBuilder();
        }
    }
}