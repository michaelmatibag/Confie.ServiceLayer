using System;
using System.IO;
using Confie.Infrastructure.FileHandling;
using Confie.WesternGeneral;
using NUnit.Framework;
using Shouldly;
using ReserveTransaction = Confie.WesternGeneral.FlatFile.ReserveTransaction;

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
        public void Claim_FileHandler_Reads_Claims()
        {
            //Arrange
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "FileHandling/FixedFiles/Claims.txt");

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

        [Test]
        public void Feature_FileHandler_Reads_Features()
        {
            //Arrange
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "FileHandling/FixedFiles/Features.txt");

            //Act
            var result = _fileHandling.ReadFile<Feature>(path);

            //Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBe(12417);
            result[1101].ClaimId.ShouldBe("201470000717");
            result[1101].CloseDate.ShouldBe(DateTime.Parse("1/1/0001 12:00:00 AM"));
            result[1101].ClosedWithoutPayment.ShouldBe(true);
            result[1101].CoverageCode.ShouldBe("BI");
            result[1101].CoverageSubCode.ShouldBe("BI");
            result[1101].Expenses.ShouldBe(516729);
            result[1101].FeatureId.ShouldBe("0003101");
            result[1101].FeatureStatus.ShouldBe("RE-OPENED");
            result[1101].OpenDate.ShouldBe(DateTime.Parse("10/13/2014 12:01:00 AM"));
            result[1101].Payments.ShouldBe(0);
            result[1101].Recoveries.ShouldBe(0);
            result[1101].ReservesAtBeginning.ShouldBe(425000);
            result[1101].ReservesAtEnd.ShouldBe(425000);
            result[1101].TotalIncurredLoss.ShouldBe(941729);
        }

        [Test]
        public void PaymentTransaction_FileHandler_Reads_PaymentTransactions()
        {
            //Arrange
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "FileHandling/FixedFiles/PaymentTransactions.txt");

            //Act
            var result = _fileHandling.ReadFile<PaymentTransaction>(path);

            //Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBe(19487);
            result[14969].CheckNumber.ShouldBe("0421573");
            result[14969].ClaimId.ShouldBe("201670006018");
            result[14969].Dummy.ShouldBe("FP");
            result[14969].FeatureId.ShouldBe("0002101");
            result[14969].PaymentAddress.ShouldBe("5230 LAS VIRGENES ROAD #100");
            result[14969].PaymentAmount.ShouldBe(27000);
            result[14969].PaymentCity.ShouldBe("CALABASAS");
            result[14969].PaymentDate.ShouldBe(DateTime.Parse("7/20/2017 12:01:00 AM"));
            result[14969].PaymentState.ShouldBe("CA");
            result[14969].PaymentStatus.ShouldBe("POSTED");
            result[14969].PaymentType.ShouldBe("Expense");
            result[14969].PaymentZip.ShouldBe("91302");
            result[14969].RecoveryType.ShouldBe(string.Empty);
        }

        [Test]
        public void ReserveTransaction_FileHandler_Reads_ReserveTransactions()
        {
            //Arrange
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "FileHandling/FixedFiles/ReserveTransactions.txt");

            //Act
            var result = _fileHandling.ReadFile<ReserveTransaction>(path);

            //Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBe(22316);
            result[11].ClaimId.ShouldBe("201370000007");
            result[11].Dummy.ShouldBe("FP");
            result[11].FeatureId.ShouldBe("0002110");
            result[11].ReserveAfter.ShouldBe(0);
            result[11].ReserveBefore.ShouldBe(189180);
            result[11].ReserveChangeDate.ShouldBe(DateTime.Parse("1/22/2014 12:02:00 AM"));
        }
    }
}