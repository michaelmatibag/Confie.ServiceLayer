using Confie.Infrastructure.Factories;
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
        private IFactory<ClaimsContext> _claimsContextFactory;
        private Confie.WesternGeneral.ClaimsRepository.ClaimsRepository _claimsRepository;
        private string _updatedUser;
        private DateTime _updatedDate;
        private DateTime _minDate;
        private Claim _claim;

        [SetUp]
        public void Setup()
        {
            _claimsContext = new ClaimsContext();
            _claimsContextFactory = new ClaimsContextFactory();
            _claimsRepository = new Confie.WesternGeneral.ClaimsRepository.ClaimsRepository(_claimsContextFactory);
            _updatedUser = Guid.NewGuid().ToString("N");
            _updatedDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _minDate = DateTime.Parse(SqlDateTime.MinValue.ToString());
            _claim = StubClaim();

            _claimsContext.Database.Delete();
        }

        [Test]
        public void SaveClaim_Saves_Claim()
        {
            //Act
            var result = _claimsRepository.SaveClaim(_claim);

            //Assert
            result.ShouldBe(true);
        }

        [Test]
        public void SaveClaims_Saves_Claims()
        {
            //Act
            var result = _claimsRepository.SaveClaims(new List<Claim> {_claim});

            //Assert
            result.ShouldBe(true);
        }

        [Test]
        public void GetClaim_Gets_Claim()
        {
            //Arrange
            _claimsRepository.SaveClaim(_claim);

            //Act
            var result = _claimsRepository.GetClaim("201670005692");

            //Assert
            result.ClaimId.ShouldBe("201670005692");
            result.UpdatedUser.ShouldBe(_updatedUser);
            result.UpdatedDate.ShouldBe(_updatedDate);
            result.Features.Count.ShouldBe(1);
            result.Features[0].FeatureId.ShouldBe("0004110");
            result.Features[0].UpdatedUser.ShouldBe(_updatedUser);
            result.Features[0].UpdatedDate.ShouldBe(_updatedDate);
            result.PaymentTransactions.Count.ShouldBe(1);
            result.PaymentTransactions[0].PaymentTransactionId.ShouldBe(1);
            result.PaymentTransactions[0].UpdatedUser.ShouldBe(_updatedUser);
            result.PaymentTransactions[0].UpdatedDate.ShouldBe(_updatedDate);
            result.ReserveTransactions.Count.ShouldBe(3);
            result.ReserveTransactions[0].ReserveTransactionId.ShouldBe(1);
            result.ReserveTransactions[0].UpdatedUser.ShouldBe(_updatedUser);
            result.ReserveTransactions[0].UpdatedDate.ShouldBe(_updatedDate);
            result.ReserveTransactions[1].UpdatedUser.ShouldBe(_updatedUser);
            result.ReserveTransactions[1].ReserveTransactionId.ShouldBe(2);
            result.ReserveTransactions[1].UpdatedDate.ShouldBe(_updatedDate);
            result.ReserveTransactions[2].UpdatedUser.ShouldBe(_updatedUser);
            result.ReserveTransactions[2].ReserveTransactionId.ShouldBe(3);
            result.ReserveTransactions[2].UpdatedDate.ShouldBe(_updatedDate);
        }

        [Test]
        public void GetClaims_Gets_Claims()
        {
            //Arrange
            _claimsRepository.SaveClaim(_claim);

            //Act
            var result = _claimsRepository.GetClaims();

            //Assert
            result.Count.ShouldBe(1);
            result[0].ClaimId.ShouldBe("201670005692");
            result[0].UpdatedUser.ShouldBe(_updatedUser);
            result[0].UpdatedDate.ShouldBe(_updatedDate);
        }

        [Test]
        public void GetFeature_Gets_Feature()
        {
            //Arrange
            _claimsRepository.SaveClaim(_claim);

            //Act
            var result = _claimsRepository.GetFeature("0004110");

            //Assert
            result.FeatureId.ShouldBe("0004110");
            result.UpdatedUser.ShouldBe(_updatedUser);
            result.UpdatedDate.ShouldBe(_updatedDate);
        }

        [Test]
        public void GetFeatures_Gets_Features()
        {
            //Arrange
            _claimsRepository.SaveClaim(_claim);

            //Act
            var result = _claimsRepository.GetFeatures();

            //Assert
            result.Count.ShouldBe(1);
            result[0].FeatureId.ShouldBe("0004110");
            result[0].UpdatedUser.ShouldBe(_updatedUser);
            result[0].UpdatedDate.ShouldBe(_updatedDate);
        }

        private Claim StubClaim()
        {
            return new Claim
            {
                ClaimDescription = "PD-OUR INSURED REAR ENDED OTHER PARTY  OUR INSURED",
                ClaimId = "201670005692",
                ClaimStatus = "RO",
                ClosedDate = _minDate,
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
                UpdatedDate = _updatedDate,
                UpdatedUser = _updatedUser,
                Features = new List<Feature>
                {
                    new Feature
                    {
                        ClaimId = "201670005692",
                        CloseDate = _minDate,
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
                        UpdatedDate = _updatedDate,
                        UpdatedUser = _updatedUser,
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
                        UpdatedDate = _updatedDate,
                        UpdatedUser = _updatedUser
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
                        UpdatedDate = _updatedDate,
                        UpdatedUser = _updatedUser
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
                        UpdatedDate = _updatedDate,
                        UpdatedUser = _updatedUser
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
                        UpdatedDate = _updatedDate,
                        UpdatedUser = _updatedUser
                    }
                }
            };
        }

        private IList<Feature> StubFeatures()
        {
            return new List<Feature>
            {
                new Feature
                {
                    ClaimId = "201670005692",
                    CloseDate = _minDate,
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
                    UpdatedDate = _updatedDate,
                    UpdatedUser = _updatedUser
                }
            };
        }
    }
}