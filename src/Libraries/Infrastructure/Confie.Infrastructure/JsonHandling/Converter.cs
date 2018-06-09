using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Confie.Infrastructure.JsonHandling
{
    public class Converter : IConverter
    {
        public JsonSerializerSettings Settings()
        {
            return new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter
                    {
                        DateTimeStyles = DateTimeStyles.AssumeUniversal
                    }
                }
            };
        }
    }
}