using System;
using Confie.Infrastructure.Configuration;
using NUnit.Framework;
using Shouldly;

namespace Confie.Infrastructure.UnitTests.Configuration
{
    [TestFixture]
    public class ConfigurationRepositoryUnitTests
    {
        private IConfigurationRepository _configurationRepository;

        [SetUp]
        public void SetUp()
        {
            _configurationRepository = new ConfigurationRepository();
        }

        [Test]
        public void GetConfigurationValue_Converts_StringCorrectly()
        {
            var result = _configurationRepository.GetConfigurationValue<string>("TestString");

            result.ShouldBe("TestStringValue");
        }

        [Test]
        public void GetConfigurationValue_Converts_IntCorrectly()
        {
            var result = _configurationRepository.GetConfigurationValue<int>("TestInt");

            result.ShouldBe(8);
        }


        [Test]
        public void GetConfigurationValue_Converts_DoubleCorrectly()
        {
            var result = _configurationRepository.GetConfigurationValue<double>("TestDouble");

            result.ShouldBe(8.25);
        }


        [Test]
        public void GetConfigurationValue_Converts_DecimalCorrectly()
        {
            var result = _configurationRepository.GetConfigurationValue<decimal>("TestDecimal");

            result.ShouldBe(8.25m);
        }


        [Test]
        public void GetConfigurationValue_Converts_DateTimeCorrectly()
        {
            var result = _configurationRepository.GetConfigurationValue<DateTime>("TestDateTime");

            result.ShouldBe(new DateTime(2018, 07, 07, 08, 25, 25));
        }


        [Test]
        public void GetConfigurationValue_Converts_BooleanCorrectly()
        {
            var result = _configurationRepository.GetConfigurationValue<bool>("TestBoolean");

            result.ShouldBe(true);
        }
    }
}