using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Confie.WesternGeneral.ClaimsRepository
{
    public class ClaimsContext : DbContext
    {
        public ClaimsContext() : base("Confie.WesternGeneral.ClaimsRepository")
        {
        }

        public virtual IDbSet<Claim> Claims { get; set; }
        public virtual IDbSet<Feature> Features { get; set; }
        public virtual IDbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public virtual IDbSet<ReserveTransaction> ReserveTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>()
                .HasKey(c => c.ClaimId);

            modelBuilder.Entity<Feature>()
                .HasKey(f => new {f.FeatureId});

            modelBuilder.Entity<PaymentTransaction>()
                .HasKey(p => p.PaymentTransactionId)
                .Property(p => p.PaymentTransactionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ReserveTransaction>()
                .HasKey(r => r.ReserveTransactionId)
                .Property(r => r.ReserveTransactionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}