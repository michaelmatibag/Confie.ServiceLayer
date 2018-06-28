using System;
using Confie.Infrastructure.Configuration;
using RestSharp;

namespace Confie.Integration.RestExecutor
{
    public class RestExecutor : IRestExecutor
    {
        private readonly IRestExecutorConfiguration _restExecutorConfiguration;
        private RestClient _restClient;

        public RestExecutor(IConfiguration configuration)
        {
            _restExecutorConfiguration = configuration.BuildFromAppConfiguration<IRestExecutorConfiguration>();
        }

        public string Get(string resource)
        {
            _restClient = new RestClient(_restExecutorConfiguration.RestApi);
            var restRequest = new RestRequest(resource, Method.GET);
            var restResponse = _restClient.Execute(restRequest);

            return restResponse.Content;
        }

        public T Get<T>(string resource) where T : new()
        {
            _restClient = new RestClient(_restExecutorConfiguration.RestApi);
            var restRequest = new RestRequest(resource, Method.GET);
            var restResponse = _restClient.Execute<T>(restRequest);

            return restResponse.Data;
        }

        public T Post<T>(T request)
        {
            throw new NotImplementedException();
        }
    }
}