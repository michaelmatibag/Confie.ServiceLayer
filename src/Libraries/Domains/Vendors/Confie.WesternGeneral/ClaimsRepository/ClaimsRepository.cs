using System.Collections.Generic;

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
                    _claimsContext.Claims.Add(new Claim
                    {
                        ClaimDescription = claim.ClaimDescription,
                        ClaimId = claim.ClaimId,
                        ClaimStatus = claim.ClaimStatus,
                        ClosedDate = claim.ClosedDate,
                        ClosedWithoutPayment = claim.ClosedWithoutPayment,
                        DriverFirstName = claim.DriverFirstName,
                        DriverLastName = claim.DriverLastName,
                        DriverLicenseId = claim.DriverLicenseId,
                        DriverLicenseState = claim.DriverLicenseState,
                        Expenses = claim.Expenses,
                        InsuredMake = claim.InsuredMake,
                        InsuredModel = claim.InsuredModel,
                        InsuredVin = claim.InsuredVin,
                        InsuredYear = claim.InsuredYear,
                        LineOfBusiness = claim.LineOfBusiness,
                        LossDate = claim.LossDate,
                        Payments = claim.Payments,
                        PercentAtFault = claim.PercentAtFault,
                        PolicyEffectiveDate = claim.PolicyEffectiveDate,
                        PolicyExpirationDate = claim.PolicyExpirationDate,
                        PolicyNumber = claim.PolicyNumber,
                        Recoveries = claim.Recoveries,
                        ReportedDate = claim.ReportedDate,
                        ReservesAtBeginning = claim.ReservesAtBeginning,
                        ReservesAtEnd = claim.ReservesAtEnd,
                        SubmissionStatus = claim.SubmissionStatus,
                        TotalIncurredLoss = claim.TotalIncurredLoss,
                        UpdatedDate = claim.UpdatedDate,
                        UpdatedUser = claim.UpdatedUser,
                        PaymentTransactions = claim.PaymentTransactions,
                        ReserveTransactions = claim.ReserveTransactions,
                        Features = claim.Features
                    });

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
            throw new System.NotImplementedException();
        }

        public Claim GetClaim(string claimId)
        {
            throw new System.NotImplementedException();
        }

        public IList<Claim> GetClaims()
        {
            throw new System.NotImplementedException();
        }
    }
}