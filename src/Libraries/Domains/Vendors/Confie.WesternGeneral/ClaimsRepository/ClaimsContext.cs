using System.Data.Entity;

namespace Confie.WesternGeneral.ClaimsRepository
{
    public class ClaimsContext : DbContext
    {
        public virtual IDbSet<Claim> Claims { get; set; }
        public virtual IDbSet<Feature> Features { get; set; }
        public virtual IDbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public virtual IDbSet<ReserveTransaction> ReserveTransactions { get; set; }
    }
}