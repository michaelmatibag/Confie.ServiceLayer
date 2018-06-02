using System;
using System.Collections.Generic;

namespace Confie.WesternGeneral
{
    public class Claim
    {
        public string ClaimId { get; set; }
        public DateTime LossDate { get; set; }
        public System.DateTime ReportedDate { get; set; }
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
        public string SubmissionStatus { get; set; }
        public string UpdatedUser { get; set; }
        public string UpdatedDate { get; set; }

        public virtual List<Feature> Features { get; set; }

        public virtual List<PaymentTransaction> PaymentTransactions { get; set; }
        
        public virtual List<ReserveTransaction> ReserveTransactions { get; set; }
    }
}