using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Confie.WesternGeneral.ClaimsRepository;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Confie.WesternGeneral.Tests.ClaimsRepository
{
    [TestFixture]
    public class ClaimsRepositoryTests
    {
        private ClaimsContext _claimsContext;
        private IDbSet<Claim> _dbSetClaim;

        [SetUp]
        public void Setup()
        {
            _claimsContext = MockRepository.GenerateMock<ClaimsContext>();
            _dbSetClaim = MockRepository.GenerateMock<IDbSet<Claim>, IQueryable>();
        }

        [Test]
        public void SaveClaim_Saves_Claim()
        {
            //Arrange
            _claimsContext.Stub(x => x.Claims).Return(_dbSetClaim);

            var claimsRepository = new WesternGeneral.ClaimsRepository.ClaimsRepository(_claimsContext);
            var claim = StubClaim();

            //Act
            var result = claimsRepository.SaveClaim(claim);

            //Assert
            result.ShouldBeTrue();
            _dbSetClaim.AssertWasCalled(x => x.Add(Arg<Claim>.Matches(y => y.ClaimId.Equals(claim.ClaimId))));
            _claimsContext.AssertWasCalled(x => x.SaveChanges());
        }

        [Test]
        public void GetClaims_Gets_Claims()
        {
            //Arrange
            var claims = StubClaims();

            _dbSetClaim.Stub(x => x.Provider).Return(claims.Provider);
            _dbSetClaim.Stub(x => x.Expression).Return(claims.Expression);
            _dbSetClaim.Stub(x => x.ElementType).Return(claims.ElementType);
            _dbSetClaim.Stub(x => x.GetEnumerator()).Return(claims.GetEnumerator());
            _claimsContext.Stub(x => x.Claims).Return(_dbSetClaim);

            var claimsRepository = new WesternGeneral.ClaimsRepository.ClaimsRepository(_claimsContext);

            //Act
            var result = claimsRepository.GetClaims();

            //Assert
            result.Count.ShouldBe(2);
            result[0].ClaimId.ShouldBe("TESTCLAIM1");
            result[1].ClaimId.ShouldBe("TESTCLAIM2");
            _claimsContext.AssertWasCalled(x => x.Claims);
        }

        private static Claim StubClaim()
        {
            return new Claim
            {
                ClaimDescription = "PD-OUR INSURED REAR ENDED OTHER PARTY  OUR INSURED",
                ClaimId = "201670005692",
                ClaimStatus = "RO",
                ClosedDate = DateTime.MinValue,
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
                TotalIncurredLoss = 187000
            };
        }

        private IQueryable<Claim> StubClaims()
        {
            return new List<Claim>
            {
                new Claim
                {
                    ClaimDescription = "TEST CLAIM 1",
                    ClaimId = "TESTCLAIM1",
                    ClaimStatus = "RO",
                    ClosedDate = DateTime.MinValue,
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
                    TotalIncurredLoss = 187000,
                },
                new Claim
                {
                    ClaimDescription = "TEST CLAIM 2",
                    ClaimId = "TESTCLAIM2",
                    ClaimStatus = "RO",
                    ClosedDate = DateTime.MinValue,
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
                    TotalIncurredLoss = 187000,
                }
            }.AsQueryable();
        }
    }
}