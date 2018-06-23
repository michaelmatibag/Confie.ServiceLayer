using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Mappers;

namespace Confie.Infrastructure.Mapper
{
    public class Mapper : IMapper
    {
        private readonly AutoMapper.Configuration _configuration;
        private readonly IMappingEngine _mappingEngine;

        public Mapper(IEnumerable<IMapperProfile> mapperProfiles)
        {
            _configuration = new AutoMapper.Configuration(new TypeMapFactory(), MapperRegistry.AllMappers());
            _mappingEngine = new MappingEngine(_configuration);

            foreach (var mapperProfile in mapperProfiles)
            {
                _configuration.CreateProfile(mapperProfile.GetType().FullName, mapperProfile.Initialize);
            }
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mappingEngine.Map<TSource, TDestination>(source);
        }

        public void AssertConfigurationIsValid()
        {
            _configuration.AssertConfigurationIsValid();
        }
    }
}