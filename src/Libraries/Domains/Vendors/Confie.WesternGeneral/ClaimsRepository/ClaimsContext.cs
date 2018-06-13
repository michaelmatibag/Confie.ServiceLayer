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
            modelBuilder.Entity<Claim>()
                .Property(c => c.SubmissionStatus).IsRequired();
            modelBuilder.Entity<Claim>()
                .Property(c => c.UpdatedUser).IsRequired();
            modelBuilder.Entity<Claim>()
                .Property(c => c.UpdatedDate).IsRequired();

            modelBuilder.Entity<Feature>()
                .HasKey(f => f.FeatureId);
            modelBuilder.Entity<Feature>()
                .Property(f => f.ClaimId).IsRequired();
            modelBuilder.Entity<Feature>()
                .Property(f => f.UpdatedUser).IsRequired();
            modelBuilder.Entity<Feature>()
                .Property(f => f.UpdatedDate).IsRequired();

            modelBuilder.Entity<PaymentTransaction>()
                .HasKey(p => p.PaymentTransactionId)
                .Property(p => p.PaymentTransactionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PaymentTransaction>()
                .Property(p => p.FeatureId).IsRequired();
            modelBuilder.Entity<PaymentTransaction>()
                .Property(p => p.UpdatedUser).IsRequired();
            modelBuilder.Entity<PaymentTransaction>()
                .Property(p => p.UpdatedDate).IsRequired();

            modelBuilder.Entity<ReserveTransaction>()
                .HasKey(r => r.ReserveTransactionId)
                .Property(r => r.ReserveTransactionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ReserveTransaction>()
                .Property(r => r.FeatureId).IsRequired();
            modelBuilder.Entity<ReserveTransaction>()
                .Property(r => r.UpdatedUser).IsRequired();
            modelBuilder.Entity<ReserveTransaction>()
                .Property(r => r.UpdatedDate).IsRequired();
        }
    }
}