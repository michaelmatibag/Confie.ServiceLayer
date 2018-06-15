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
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    claimsContext.Claims.Add(claim);
                    claimsContext.SaveChanges();
                }

                return true;
            }
            catch
            {
                //TODO:  Add logging.

                return false;
            }
        }

        public bool SaveClaims(IList<Claim> claims)
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    foreach (var claim in claims)
                    {
                        claimsContext.Claims.Add(claim);
                    }

                    claimsContext.SaveChanges();
                }

                return true;
            }
            catch
            {
                //TODO:  Add logging.

                return false;
            }
        }

        public Claim GetClaim(string claimId)
        {
            try
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
            catch
            {
                //TODO:  Add logging.

                return null;
            }
        }

        public IList<Claim> GetClaims()
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    return claimsContext.Claims
                        .ToList();
                }
            }
            catch
            {
                //TODO:  Add logging.

                return null;
            }
        }

        public bool SaveFeature(Feature feature)
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    claimsContext.Features.Add(feature);
                    claimsContext.SaveChanges();
                }

                return true;
            }
            catch
            {
                //TODO:  Add logging.

                return false;
            }
        }

        public bool SaveFeatures(IList<Feature> features)
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    foreach (var feature in features)
                    {
                        claimsContext.Features.Add(feature);
                    }
                    
                    claimsContext.SaveChanges();
                }

                return true;
            }
            catch
            {
                //TODO:  Add logging.

                return false;
            }
        }

        public Feature GetFeature(string featureId)
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    return claimsContext.Features
                        .Include(x => x.PaymentTransactions)
                        .Include(x => x.ReserveTransactions)
                        .FirstOrDefault(x => x.FeatureId == featureId);
                }
            }
            catch
            {
                //TODO:  Add logging.

                return null;
            }
        }

        public IList<Feature> GetFeatures()
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    return claimsContext.Features
                        .ToList();
                }
            }
            catch
            {
                //TODO:  Add logging.

                return null;
            }
        }

        public IList<Feature> GetFeatures(string claimId)
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    return claimsContext.Features
                        .Where(x => x.ClaimId == claimId)
                        .ToList();
                }
            }
            catch
            {
                //TODO:  Add logging.

                return null;
            }
        }

        public bool SavePaymentTransaction(PaymentTransaction paymentTransaction)
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    claimsContext.PaymentTransactions.Add(paymentTransaction);
                    claimsContext.SaveChanges();
                }

                return true;
            }
            catch
            {
                //TODO:  Add logging.

                return false;
            }
        }

        public bool SavePaymentTransactions(IList<PaymentTransaction> paymentTransactions)
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    foreach (var paymentTransaction in paymentTransactions)
                    {
                        claimsContext.PaymentTransactions.Add(paymentTransaction);
                    }

                    claimsContext.SaveChanges();
                }

                return true;
            }
            catch
            {
                //TODO:  Add logging.

                return false;
            }
        }

        public PaymentTransaction GetPaymentTransaction(int paymentTransactionId)
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    return claimsContext.PaymentTransactions
                        .FirstOrDefault(x => x.PaymentTransactionId == paymentTransactionId);
                }
            }
            catch
            {
                //TODO:  Add logging.

                return null;
            }
        }

        public IList<PaymentTransaction> GetPaymentTransactions(string featureId)
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    return claimsContext.PaymentTransactions
                        .Where(x => x.FeatureId == featureId)
                        .ToList();
                }
            }
            catch
            {
                //TODO:  Add logging.

                return null;
            }
        }

        public IList<PaymentTransaction> GetPaymentTransactions()
        {
            try
            {
                using (var claimsContext = _claimsContextFactory.Create())
                {
                    return claimsContext.PaymentTransactions
                        .ToList();
                }
            }
            catch
            {
                //TODO:  Add logging.

                return null;
            }
        }
    }
}