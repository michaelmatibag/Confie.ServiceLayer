using System;

namespace Confie.WesternGeneral
{
    public class PaymentTransaction
    {
        public int PaymentTransactionId { get; set; }
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
        public string UpdatedUser { get; set; }
        public string UpdatedDate { get; set; }

        public string ClaimId { get; set; }
        public virtual Claim Claim { get; set; }

        public string FeatureId { get; set; }
        public virtual Feature Feature { get; set; }
    }
}