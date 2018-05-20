using System;

namespace Confie.WesternGeneral.FlatFile
{
    public class Feature
    {
        public string ClaimId { get; set; }
        public string FeatureId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string FeatureStatus { get; set; }
        public string CoverageCode { get; set; }
        public string CoverageSubCode { get; set; }
        public bool ClosedWithoutPayment { get; set; }
        public decimal Payments { get; set; }
        public decimal Recoveries { get; set; }
        public decimal Expenses { get; set; }
        public decimal ReservesAtBeginning { get; set; }
        public decimal ReservesAtEnd { get; set; }
        public decimal TotalIncurredLoss { get; set; }
    }
}