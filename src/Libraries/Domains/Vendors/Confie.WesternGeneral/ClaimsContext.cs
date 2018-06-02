using System.Data.Entity;

namespace Confie.WesternGeneral
{
    public class ClaimsContext : DbContext
    {
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public DbSet<ReserveTransaction> ReserveTransactions { get; set; }
    }
}