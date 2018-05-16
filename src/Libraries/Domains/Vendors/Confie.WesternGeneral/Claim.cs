using System;

namespace Confie.WesternGeneral
{
    public class Claim
    {
        public string ClaimId { get; set; }
        public DateTime LossDate { get; set; }
        public DateTime ReportedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public string ClaimStatus { get; set; }
        public bool ClosedWithoutPayment { get; set; }
        public int PercentAtFault { get; set; }
        public string ClaimDescription { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpirationDate { get; set; }
        public string PolicyNumber { get; set; }
        public string LineOfBusiness { get; set; }
        public string DriverLastName { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverLicenseId { get; set; }
        public string DriverLicenseState { get; set; }
        public string InsuredVin { get; set; }
        public string InsuredMake { get; set; }
        public string InsuredModel { get; set; }
        public int InsuredYear { get; set; }
        public decimal Payments { get; set; }
        public decimal Recoveries { get; set; }
        public decimal Expenses { get; set; }
        public decimal ReservesAtBeginning { get; set; }
        public decimal ReservesAtEnd { get; set; }
        public decimal TotalIncurredLoss { get; set; }
    }
}