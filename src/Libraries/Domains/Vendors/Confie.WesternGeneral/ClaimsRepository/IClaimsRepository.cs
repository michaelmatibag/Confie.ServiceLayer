using System.Collections.Generic;

namespace Confie.WesternGeneral.ClaimsRepository
{
    public interface IClaimsRepository
    {
        bool SaveClaim(Claim claim);
        bool SaveClaims(IList<Claim> claims);
        Claim GetClaim(string claimId);
        IList<Claim> GetClaims();
        bool SaveFeature(Feature feature);
        bool SaveFeatures(IList<Feature> features);
        Feature GetFeature(string featureId);
        IList<Feature> GetFeatures();
        IList<Feature> GetFeatures(string claimId);
        bool SavePaymentTransaction(PaymentTransaction paymentTransaction);
        bool SavePaymentTransactions(IList<PaymentTransaction> paymentTransactions);
        PaymentTransaction GetPaymentTransaction(int paymentTransactionId);
        IList<PaymentTransaction> GetPaymentTransactions(string featureId);
        IList<PaymentTransaction> GetPaymentTransactions();
    }
}