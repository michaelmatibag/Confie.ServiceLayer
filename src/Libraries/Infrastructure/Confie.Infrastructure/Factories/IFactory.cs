namespace Confie.Infrastructure.Factories
{
    public interface IFactory<T>
    {
        T Create();
    }
}