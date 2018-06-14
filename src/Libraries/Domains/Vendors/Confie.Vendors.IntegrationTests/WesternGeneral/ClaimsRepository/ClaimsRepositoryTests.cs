using Confie.WesternGeneral;
using Confie.WesternGeneral.ClaimsRepository;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Confie.Vendors.IntegrationTests.WesternGeneral.ClaimsRepository
{
    [TestFixture]
    public class ClaimsRepositoryTests
    {
        private ClaimsContext _claimsContext;
        private Confie.WesternGeneral.ClaimsRepository.ClaimsRepository _claimsRepository;

        [SetUp]
        public void Setup()
        {
            _claimsContext = new ClaimsContext();
            _claimsRepository = new Confie.WesternGeneral.ClaimsRepository.ClaimsRepository(_claimsContext);
        }

        [Test, Explicit]
        public void SaveClaim_Saves_Claim()
        {
            //Arrange
            var updatedDate = DateTime.Now;
            var claim = StubClaim("TestUser", updatedDate);

            //Act
            var result = _claimsRepository.SaveClaim(claim);

            //Assert
            result.ShouldBeTrue();
        }

        [Test, Explicit]
        public void GetClaims_Gets_Claims()
        {
            //Act
            var result = _claimsRepository.GetClaims();

            //Assert
            result.Count.ShouldBe(1);
            result[0].ClaimId.ShouldBe("201670005692");
            result[0].Features.Count.ShouldBe(1);
            result[0].Features[0].FeatureId.ShouldBe("0004110");
        }

        private static Claim StubClaim(string updatedUser, DateTime updatedDate)
        {
            var minDate = DateTime.Parse(SqlDateTime.MinValue.ToString());

            return new Claim
            {
                ClaimDescription = "PD-OUR INSURED REAR ENDED OTHER PARTY  OUR INSURED",
                ClaimId = "201670005692",
                ClaimStatus = "RO",
                ClosedDate = minDate,
                ClosedWithoutPayment = false,
                DriverFirstName = "HUGO",
                DriverLastName = "RAMIREZ",
                DriverLicenseId = string.Empty,
                DriverLicenseState = "IT",
                Expenses = 27000,
                InsuredMake = "TYTA",
                InsuredModel = "COROLLA/CE SEDAN 4D",
                InsuredVin = "1NXBA02E3VZ637068",
                InsuredYear = 1997,
                LineOfBusiness = "AUTO",
                LossDate = DateTime.Parse("10/21/2016 12:01:00 AM"),
                Payments = 0,
                PercentAtFault = 0,
                PolicyEffectiveDate = DateTime.Parse("10/12/2016 12:01:00 AM"),
                PolicyExpirationDate = DateTime.Parse("10/12/2017 12:01:00 AM"),
                PolicyNumber = "WGP0033894",
                Recoveries = 0,
                ReportedDate = DateTime.Parse("10/24/2016 12:01:00 AM"),
                ReservesAtBeginning = 100000,
                ReservesAtEnd = 160000,
                SubmissionStatus = SubmissionStatus.New,
                TotalIncurredLoss = 187000,
                UpdatedDate = updatedDate,
                UpdatedUser = updatedUser,
                Features = new List<Feature>
                {
                    new Feature
                    {
                        ClaimId = "201670005692",
                        CloseDate = minDate,
                        ClosedWithoutPayment = true,
                        CoverageCode = "PD",
                        CoverageSubCode = "PD",
                        Expenses = 27000,
                        FeatureId = "0004110",
                        FeatureStatus = "RE-OPENED",
                        OpenDate = DateTime.Parse("10/24/2016 12:01:00 AM"),
                        Payments = 0,
                        Recoveries = 0,
                        ReservesAtBeginning = 100000,
                        ReservesAtEnd = 160000,
                        TotalIncurredLoss = 187000,
                        UpdatedDate = updatedDate,
                        UpdatedUser = updatedUser,
                    }
                },
                PaymentTransactions = new List<PaymentTransaction>
                {
                    new PaymentTransaction
                    {
                        CheckNumber = "0410817",
                        ClaimId = "201670005692",
                        Dummy = "FP",
                        FeatureId = "0004110",
                        PaymentAddress = "5230 LAS VIRGENES ROAD #100",
                        PaymentAmount = 27000,
                        PaymentCity = "CALABASAS",
                        PaymentDate = DateTime.Parse("12/13/2016 12:01:00 AM"),
                        PaymentState = "CA",
                        PaymentStatus = "POSTED",
                        PaymentTransactionId = 0,
                        PaymentType = "Expense",
                        PaymentZip = "91302",
                        RecoveryType = string.Empty,
                        UpdatedDate = updatedDate,
                        UpdatedUser = updatedUser
                    }
                },
                ReserveTransactions = new List<ReserveTransaction>
                {
                    new ReserveTransaction
                    {
                        ClaimId = "201670005692",
                        Dummy = "OC",
                        FeatureId = "0004110",
                        ReserveAfter = 100000,
                        ReserveBefore = 0,
                        ReserveChangeDate = DateTime.Parse("11/2/2016 12:01:00 AM"),
                        ReserveTransactionId = 0,
                        UpdatedDate = updatedDate,
                        UpdatedUser = updatedUser
                    },
                    new ReserveTransaction
                    {
                        ClaimId = "201670005692",
                        Dummy = "NC",
                        FeatureId = "0004110",
                        ReserveAfter = 0,
                        ReserveBefore = 0,
                        ReserveChangeDate = DateTime.Parse("12/13/2016 12:02:00 AM"),
                        ReserveTransactionId = 0,
                        UpdatedDate = updatedDate,
                        UpdatedUser = updatedUser
                    },
                    new ReserveTransaction
                    {
                        ClaimId = "201670005692",
                        Dummy = "RO",
                        FeatureId = "0004110",
                        ReserveAfter = 160000,
                        ReserveBefore = 0,
                        ReserveChangeDate = DateTime.Parse("2/16/2018 12:03:00 AM"),
                        ReserveTransactionId = 0,
                        UpdatedDate = updatedDate,
                        UpdatedUser = updatedUser
                    }
                }
            };
        }
    }
}