using System;

namespace Confie.WesternGeneral
{
    public class ReserveTransactions
    {
        public string ClaimId { get; set; }
        public string FeatureId { get; set; }
        public DateTime ReserveChangeDate { get; set; }
        public decimal ReserveBefore { get; set; }
        public decimal ReserveAfter { get; set; }
    }
}