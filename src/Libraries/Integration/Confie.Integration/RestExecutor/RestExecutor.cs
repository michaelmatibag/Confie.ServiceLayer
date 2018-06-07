using Confie.Infrastructure.Configuration;
using RestSharp;

namespace Confie.Integration.RestExecutor
{
    public class RestExecutor : IRestExecutor
    {
        private readonly IConfiguration _configuration;
        private IRestExecutorConfiguration _restExecutorConfiguration;
        private RestClient _restClient;

        public RestExecutor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Execute(string request)
        {
            _restExecutorConfiguration = _configuration.BuildFromAppConfiguration<IRestExecutorConfiguration>();
            _restClient = new RestClient(_restExecutorConfiguration.RestApi);

            var restRequest = new RestRequest(request);
            var restResponse = _restClient.Execute(restRequest);

            return restResponse.Content;
        }
    }
}