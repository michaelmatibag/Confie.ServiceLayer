using System.Collections.Generic;
using System.Linq;

namespace Confie.WesternGeneral.ClaimsRepository
{
    public class ClaimsRepository : IClaimsRepository
    {
        private readonly ClaimsContext _claimsContext;

        public ClaimsRepository(ClaimsContext claimsContext)
        {
            _claimsContext = claimsContext;
        }

        public bool SaveClaim(Claim claim)
        {
            try
            {
                using (_claimsContext)
                {
                    _claimsContext.Claims.Add(claim);
                    _claimsContext.SaveChanges();
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
                using (_claimsContext)
                {
                    foreach (var claim in claims)
                    {
                        _claimsContext.Claims.Add(claim);
                    }

                    _claimsContext.SaveChanges();
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
                using (_claimsContext)
                {
                    return _claimsContext.Claims.FirstOrDefault(x => x.ClaimId == claimId);
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
                using (_claimsContext)
                {
                    return _claimsContext.Claims.ToList();
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