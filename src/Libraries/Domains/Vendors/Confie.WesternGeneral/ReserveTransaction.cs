using System;

namespace Confie.WesternGeneral
{
    public class ReserveTransaction
    {
        public int ReserveTransactionId { get; set; }
        public DateTime ReserveChangeDate { get; set; }
        public decimal ReserveBefore { get; set; }
        public decimal ReserveAfter { get; set; }
        public string UpdatedUser { get; set; }
        public string UpdatedDate { get; set; }

        public string ClaimId { get; set; }
        public virtual Claim Claim { get; set; }

        public string FeatureId { get; set; }
        public virtual Feature Feature { get; set; }
    }
}