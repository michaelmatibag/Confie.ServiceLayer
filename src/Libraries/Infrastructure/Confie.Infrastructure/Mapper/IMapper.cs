﻿namespace Confie.Infrastructure.Mapper
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}