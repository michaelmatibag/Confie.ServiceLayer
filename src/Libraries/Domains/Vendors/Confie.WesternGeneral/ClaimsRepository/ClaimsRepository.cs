using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Confie.Infrastructure.Factories;

namespace Confie.WesternGeneral.ClaimsRepository
{
    public class ClaimsRepository : IClaimsRepository
    {
        private readonly IFactory<ClaimsContext> _claimsContextFactory;

        public ClaimsRepository(IFactory<ClaimsContext> claimsContextFactory)
        {
            _claimsContextFactory = claimsContextFactory;
        }

        public bool SaveClaim(Claim claim)
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                if (claimsContext.Claims.Any(x => x.ClaimId == claim.ClaimId)) return false;

                claimsContext.Claims.Add(claim);

                return claimsContext.SaveChanges() > 0;
            }
        }

        public bool SaveClaims(IList<Claim> claims)
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                foreach (var claim in claims)
                {
                    if (claimsContext.Claims.Any(x => x.ClaimId == claim.ClaimId)) continue;

                    claimsContext.Claims.Add(claim);
                }

                return claimsContext.SaveChanges() > 0;
            }
        }

        public Claim GetClaim(string claimId)
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                return claimsContext.Claims
                    .Include(x => x.Features)
                    .Include(x => x.PaymentTransactions)
                    .Include(x => x.ReserveTransactions)
                    .FirstOrDefault(x => x.ClaimId == claimId);
            }
        }

        public IList<Claim> GetClaims()
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                return claimsContext.Claims
                    .ToList();
            }
        }

        public bool SaveFeature(Feature feature)
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                claimsContext.Features.Add(feature);

                return claimsContext.SaveChanges() > 0;
            }
        }

        public bool SaveFeatures(IList<Feature> features)
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                foreach (var feature in features)
                {
                    claimsContext.Features.Add(feature);
                }

                return claimsContext.SaveChanges() > 0;
            }
        }

        public Feature GetFeature(string featureId)
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                return claimsContext.Features
                    .Include(x => x.PaymentTransactions)
                    .Include(x => x.ReserveTransactions)
                    .FirstOrDefault(x => x.FeatureId == featureId);
            }
        }

        public IList<Feature> GetFeatures()
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                return claimsContext.Features
                    .ToList();
            }
        }

        public IList<Feature> GetFeatures(string claimId)
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                return claimsContext.Features
                    .Where(x => x.ClaimId == claimId)
                    .ToList();
            }
        }

        public bool SavePaymentTransaction(PaymentTransaction paymentTransaction)
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                claimsContext.PaymentTransactions.Add(paymentTransaction);

                return claimsContext.SaveChanges() > 0;
            }
        }

        public bool SavePaymentTransactions(IList<PaymentTransaction> paymentTransactions)
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                foreach (var paymentTransaction in paymentTransactions)
                {
                    claimsContext.PaymentTransactions.Add(paymentTransaction);
                }

                return claimsContext.SaveChanges() > 0;
            }
        }

        public PaymentTransaction GetPaymentTransaction(int paymentTransactionId)
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                return claimsContext.PaymentTransactions
                    .FirstOrDefault(x => x.PaymentTransactionId == paymentTransactionId);
            }
        }

        public IList<PaymentTransaction> GetPaymentTransactions(string featureId)
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                return claimsContext.PaymentTransactions
                    .Where(x => x.FeatureId == featureId)
                    .ToList();
            }
        }

        public IList<PaymentTransaction> GetPaymentTransactions()
        {
            using (var claimsContext = _claimsContextFactory.Create())
            {
                return claimsContext.PaymentTransactions
                    .ToList();
            }
        }
    }
}