using AutoMapper;

namespace Confie.Infrastructure.Mapper
{
    public interface IMapperProfile
    {
        void Initialize(IProfileExpression profileExpression);
    }
}