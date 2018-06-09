using System.IO;
using Confie.Infrastructure.JsonHandling;
using Confie.PolicyOne;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Confie.Infrastructure.Tests.JsonHandling
{
    [TestFixture]
    public class JsonHandlingTests
    {
        private IConverter _converter;

        [SetUp]
        public void Setup()
        {
            _converter = MockRepository.GenerateMock<IConverter>();
        }

        [Test]
        public void FromJson_Generates_Object()
        {
            //Arrange
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "JsonHandling/JsonFiles/PolicyOneClaims.json");
            var json = File.ReadAllText(path);
            var jsonHandling = new Infrastructure.JsonHandling.JsonHandling(_converter);

            //Act
            var result = jsonHandling.FromJson<PolicyOneClaims>(json);

            //Assert
            result.ShouldBeOfType(typeof(PolicyOneClaims));
            result.Claims.Count.ShouldBe(1);
            result.Claims[0].ClaimId.ShouldBe("TESTCLAIMID");
            result.Claims[0].Features.Count.ShouldBe(1);
            result.Claims[0].Features[0].ClaimFeatureId.ShouldBe("TESTCLAIMFEATUREID");
            result.Claims[0].Features[0].Payments.Count.ShouldBe(1);
            result.Claims[0].Features[0].Payments[0].PaymentId.ShouldBe("TESTPAYMENTID");
            result.Claims[0].Features[0].Reserves.Count.ShouldBe(1);
            result.Claims[0].Features[0].Reserves[0].ClaimReserveId.ShouldBe("TESTCLAIMRESERVEID");
        }
    }
}