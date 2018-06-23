using System.Collections.Generic;
using Confie.Infrastructure.Mapper;
using Confie.WesternGeneral.Mapper;
using NUnit.Framework;

namespace Confie.Vendors.UnitTests.WesternGeneral.Mapper
{
    [TestFixture]
    public class WesternGeneralMapperProfileTests
    {
        private Infrastructure.Mapper.Mapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mapper = new Infrastructure.Mapper.Mapper(GetMapperProfiles());
        }

        [Test]
        public void Configuration_ShouldBe_Valid()
        {
            _mapper.AssertConfigurationIsValid();
        }

        private static IEnumerable<IMapperProfile> GetMapperProfiles()
        {
            yield return new WesternGeneralMapperProfile();
        }
    }
}