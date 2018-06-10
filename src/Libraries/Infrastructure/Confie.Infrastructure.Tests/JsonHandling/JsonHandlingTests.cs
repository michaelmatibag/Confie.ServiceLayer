using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Confie.Infrastructure.JsonHandling;
using Confie.PolicyOne;
using Newtonsoft.Json.Linq;
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

        [Test]
        public void ToJson_Generates_JsonString()
        {
            //Arrange
            var jsonHandling = new Infrastructure.JsonHandling.JsonHandling(_converter);

            //Act
            var result = jsonHandling.ToJson(GetPolicyOneClaims());
            var json = JObject.Parse(result);

            //Assert
            result.ShouldNotBeNullOrWhiteSpace();
            result.ShouldContain("TestClaimId");
            (from p in json["claims"] select (string) p["claimId"])
                .FirstOrDefault()
                .ShouldBe("TestClaimId");
        }

        private static PolicyOneClaims GetPolicyOneClaims()
        {
            return new PolicyOneClaims
            {
                Claims = new List<Claim>
                {
                    new Claim
                    {
                        IncidentDriver = new IncidentDriver
                        {
                            FirstName = "TestFirstName",
                            LastName = "TestLastName",
                            LicenseNumber = "TestLicenseNumber",
                            LicenseState = "TestLicenseState"
                        },
                        InsuredDriver = new InsuredDriver
                        {
                            FirstName = "TestFirstName",
                            LastName = "TestLastName",
                            LicenseNumber = "TestLicenseNumber",
                            LicenseState = "TestLicenseState",
                            StreetAddress = "TestStreetAddress",
                            State = "TestState",
                            City = "TestCity"
                        },
                        NamedInsured = new NamedInsured
                        {
                            FirstName = "TestFirstName",
                            LastName = "TestLastName",
                            StreetAddress = "TestStreetAddress",
                            State = "TestState",
                            City = "TestCity"
                        },
                        Policy = new Policy
                        {
                            EffectiveDate = DateTimeOffset.Now,
                            ExpirationDate = DateTimeOffset.Now,
                            Number = "TestNumber"
                        },
                        ClaimId = "TestClaimId",
                        Number = "TestNumber",
                        ImportedTimezoneId = 0,
                        LossDate = DateTimeOffset.Now,
                        ClaimLineOfBusinessType = "TestClaimLineOfBusinessType",
                        ClaimSource = "TestClaimSource",
                        ReportedDate = DateTimeOffset.Now,
                        ClosedDate = DateTimeOffset.Now,
                        Status = "TestStatus",
                        Description = "TestDescription",
                        AccidentType = "TestAccidentType",
                        Features = new List<Feature>
                        {
                            new Feature
                            {
                                ClaimFeatureId = "TestClaimFeatureId",
                                OpenDate = DateTimeOffset.Now,
                                ClosedDate = DateTimeOffset.Now,
                                Status = "TestStatus",
                                Coverage = "TestCoverage",
                                CoverageSubCode = "TestCoverageSubCode",
                                PercentAtFault = 0,
                                LossDescription = "TestLossDescription",
                                Claimant = new Claimant
                                {
                                    FirstName = "TestFirstName",
                                    LastName = "TestLastName",
                                    State = "TestState",
                                    City = "TestCity",
                                    BusinessName = "TestBusinessName",
                                    Driver = new NamedInsured
                                    {
                                        FirstName = "TestFirstName",
                                        LastName = "TestLastName",
                                        State = "TestState",
                                        City = "TestCity"
                                    },
                                    Vehicle = new Vehicle
                                    {
                                        Make = "TestMake",
                                        Model = "TestModel",
                                        Year = 0,
                                        Vin = "TestVin",
                                        LicenseNumber = "TestLicenseNumber",
                                        LicenseState = "TestLicenseState"
                                    }
                                },
                                Number = "TestNumber",
                                InsuredVehicle = new Vehicle
                                {
                                    Make = "TestMake",
                                    Model = "TestModel",
                                    Year = 0,
                                    Vin = "TestVin",
                                    LicenseNumber = "TestLicenseNumber",
                                    LicenseState = "TestLicenseState"
                                },
                                Payments = new List<Payment>
                                {
                                    new Payment
                                    {
                                        PaymentId = "TestPaymentId",
                                        Date = DateTimeOffset.Now,
                                        Amount = 0,
                                        Status = "TestStatus",
                                        PaymentType = "TestPaymentType",
                                        RecoveryType = "TestRecoveryType",
                                        CheckNumber = "TestCheckNumber",
                                        BusinessName = "TestBusinessName",
                                        LastName = "TestLastName",
                                        FirstName = "TestFirstName",
                                        Address = "TestAddress",
                                        City = "TestCity",
                                        State = "TestState",
                                        Zip = "TestZip"
                                    }
                                },
                                Reserves = new List<Reserve>
                                {
                                    new Reserve
                                    {
                                        ClaimReserveId = "TestClaimReserveId",
                                        ChangeDate = DateTimeOffset.Now,
                                        Amount = 0
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}