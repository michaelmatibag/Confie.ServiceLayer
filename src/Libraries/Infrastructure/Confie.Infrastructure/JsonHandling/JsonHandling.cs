using Newtonsoft.Json;

namespace Confie.Infrastructure.JsonHandling
{
    public class JsonHandling : IJsonHandling
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public JsonHandling(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }

        public string ToJson<T>(T input)
        {
            return JsonConvert.SerializeObject(input, _jsonSerializerSettings);
        }
    }
}