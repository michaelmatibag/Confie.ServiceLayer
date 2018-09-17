namespace Confie.Infrastructure.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}