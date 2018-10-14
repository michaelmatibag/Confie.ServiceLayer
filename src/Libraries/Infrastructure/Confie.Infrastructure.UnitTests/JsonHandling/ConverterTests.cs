using System.Globalization;
using Confie.Infrastructure.JsonHandling;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using Shouldly;

namespace Confie.Infrastructure.UnitTests.JsonHandling
{
    [TestFixture]
    public class ConverterTests
    {
        private Converter _converter;
        private JsonSerializerSettings _settings;

        [SetUp]
        public void Setup()
        {
            _converter = new Converter();
            _settings = _converter.Settings();
        }

        [Test]
        public void Settings_Returns_ExpectedSettings()
        {
            //Assert
            _settings.MetadataPropertyHandling.ShouldBe(MetadataPropertyHandling.Ignore);
            _settings.DateParseHandling.ShouldBe(DateParseHandling.None);
            _settings.Converters.ShouldNotBeNull();
            _settings.Converters.ShouldHaveSingleItem();
        }

        [Test]
        public void Converters_Has_IsoDateTimeConverter()
        {
            var converter = (IsoDateTimeConverter) _settings.Converters[0];

            //Assert
            converter.ShouldBeOfType<IsoDateTimeConverter>();
            converter.DateTimeStyles.ShouldBe(DateTimeStyles.AssumeUniversal);
        }
    }
}