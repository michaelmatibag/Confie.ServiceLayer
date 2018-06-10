using Newtonsoft.Json;

namespace Confie.Infrastructure.JsonHandling
{
    public class JsonHandling : IJsonHandling
    {
        private readonly IConverter _converter;

        public JsonHandling(IConverter converter)
        {
            _converter = converter;
        }

        public T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _converter.Settings());
        }

        public string ToJson<T>(T input)
        {
            return JsonConvert.SerializeObject(input, _converter.Settings());
        }
    }
}