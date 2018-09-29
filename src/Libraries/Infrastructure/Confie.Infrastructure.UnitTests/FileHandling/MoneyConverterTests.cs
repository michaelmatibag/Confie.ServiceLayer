using Confie.Infrastructure.FileHandling;
using NUnit.Framework;
using Shouldly;

namespace Confie.Infrastructure.UnitTests.FileHandling
{
    [TestFixture]
    public class MoneyConverterTests
    {
        private MoneyConverter _moneyConverter;

        [SetUp]
        public void Setup()
        {
            _moneyConverter = new MoneyConverter();
        }

        [Test]
        public void StringToField_Converts_ToDecimal()
        {
            var result = _moneyConverter.StringToField("12345678912345678");

            result.ShouldBeOfType<decimal>();
        }

        [Test]
        public void StringToField_Has_TwoDecimalPlaces()
        {
            var result = _moneyConverter.StringToField("12345678912345678");

            result.ShouldBe(123456789123456.78);
        }
    }
}