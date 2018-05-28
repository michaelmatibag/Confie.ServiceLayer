using System;
using System.IO;
using Confie.Infrastructure.FileHandling;
using Confie.WesternGeneral.FlatFile;
using NUnit.Framework;
using Shouldly;

namespace Confie.Infrastructure.Tests.FileHandling
{
    [TestFixture]
    public class FixedFileHandlingTests
    {
        private IFileHandling _fileHandling;

        [SetUp]
        public void SetUp()
        {
            _fileHandling = new FixedFileHandling();
        }

        [Test]
        public void ClaimReadClaims()
        {
            //Arrange
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"FileHandling\FixedFiles\Claim.txt");

            //Act
            var result = _fileHandling.ReadFile<Claim>(path);

            //Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBe(9031);
            result[5586].ClaimDescription.ShouldBe("PD-OUR INSURED REAR ENDED OTHER PARTY  OUR INSURED");
            result[5586].ClaimId.ShouldBe("201670005692");
            result[5586].ClaimStatus.ShouldBe("RO");
            result[5586].ClosedDate.ShouldBe(DateTime.MinValue);
            result[5586].ClosedWithoutPayment.ShouldBe(false);
            result[5586].DriverFirstName.ShouldBe("HUGO");
            result[5586].DriverLastName.ShouldBe("RAMIREZ");
            result[5586].DriverLicenseId.ShouldBe(string.Empty);
            result[5586].DriverLicenseState.ShouldBe("IT");
            result[5586].Expenses.ShouldBe(27000);
            result[5586].InsuredMake.ShouldBe("TYTA");
            result[5586].InsuredModel.ShouldBe("COROLLA/CE SEDAN 4D");
            result[5586].InsuredVin.ShouldBe("1NXBA02E3VZ637068");
            result[5586].InsuredYear.ShouldBe(1997);
            result[5586].LineOfBusiness.ShouldBe("AUTO");
            result[5586].LossDate.ShouldBe(DateTime.Parse("10/21/2016 12:01:00 AM"));
            result[5586].Payments.ShouldBe(0);
            result[5586].PercentAtFault.ShouldBe(0);
            result[5586].PolicyEffectiveDate.ShouldBe(DateTime.Parse("10/12/2016 12:01:00 AM"));
            result[5586].PolicyExpirationDate.ShouldBe(DateTime.Parse("10/12/2017 12:01:00 AM"));
            result[5586].PolicyNumber.ShouldBe("WGP0033894");
            result[5586].Recoveries.ShouldBe(0);
            result[5586].ReportedDate.ShouldBe(DateTime.Parse("10/24/2016 12:01:00 AM"));
            result[5586].ReservesAtBeginning.ShouldBe(100000);
            result[5586].ReservesAtEnd.ShouldBe(160000);
            result[5586].TotalIncurredLoss.ShouldBe(187000);
        }
    }
}
