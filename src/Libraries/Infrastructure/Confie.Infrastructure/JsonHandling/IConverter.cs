using Newtonsoft.Json;

namespace Confie.Infrastructure.JsonHandling
{
    public interface IConverter
    {
        JsonSerializerSettings Settings();
    }
}