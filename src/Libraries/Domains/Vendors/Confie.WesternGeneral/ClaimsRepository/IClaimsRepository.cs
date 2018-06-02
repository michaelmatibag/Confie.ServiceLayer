using System.Collections.Generic;

namespace Confie.WesternGeneral.ClaimsRepository
{
    public interface IClaimsRepository
    {
        bool SaveClaim(Claim claim);
        bool SaveClaims(IList<Claim> claims);
        Claim GetClaim(string claimId);
        IList<Claim> GetClaims();
    }
}