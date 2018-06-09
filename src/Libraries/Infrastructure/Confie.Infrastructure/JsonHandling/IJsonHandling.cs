namespace Confie.Infrastructure.JsonHandling
{
    public interface IJsonHandling
    {
        T FromJson<T>(string json);

        string ToJson<T>(T input);
    }
}