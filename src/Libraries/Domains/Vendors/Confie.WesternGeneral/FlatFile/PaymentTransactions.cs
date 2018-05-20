using System;

namespace Confie.WesternGeneral.FlatFile
{
    public class PaymentTransactions
    {
        public string ClaimId { get; set; }
        public string FeatureId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentType { get; set; }
        public string RecoveryType { get; set; }
        public string CheckNumber { get; set; }
        public string PaymentAddress { get; set; }
        public string PaymentCity { get; set; }
        public string PaymentState { get; set; }
        public string PaymentZip { get; set; }
    }
}