using AutoMapper;
using Confie.Infrastructure.Mapper;
using Confie.PolicyOne;

namespace Confie.WesternGeneral.Mapper
{
    public class WesternGeneralMapperProfile : IMapperProfile
    {
        public void Initialize(IProfileExpression profileExpression)
        {
            profileExpression.CreateMap<Claim, IncidentDriver>()
                .ForMember(d => d.FirstName, s => s.MapFrom(x => x.DriverFirstName))
                .ForMember(d => d.LastName, s => s.MapFrom(x => x.DriverLastName))
                .ForMember(d => d.LicenseNumber, s => s.MapFrom(x => x.DriverLicenseId))
                .ForMember(d => d.LicenseState, s => s.MapFrom(x => x.DriverLicenseState));

            profileExpression.CreateMap<Claim, InsuredDriver>()
                .ForMember(d => d.LicenseNumber, s => s.MapFrom(x => x.DriverLicenseId))
                .ForMember(d => d.City, s => s.Ignore())
                .ForMember(d => d.FirstName, s => s.MapFrom(x => x.DriverFirstName))
                .ForMember(d => d.LastName, s => s.MapFrom(x => x.DriverLastName))
                .ForMember(d => d.LicenseState, s => s.MapFrom(x => x.DriverLicenseState))
                .ForMember(d => d.State, s => s.Ignore())
                .ForMember(d => d.StreetAddress, s => s.Ignore());

            profileExpression.CreateMap<Claim, NamedInsured>()
                .ForMember(d => d.State, s => s.Ignore())
                .ForMember(d => d.City, s => s.Ignore())
                .ForMember(d => d.FirstName, s => s.MapFrom(x => x.DriverFirstName))
                .ForMember(d => d.LastName, s => s.MapFrom(x => x.DriverLastName))
                .ForMember(d => d.StreetAddress, s => s.Ignore());

            profileExpression.CreateMap<Claim, Policy>()
                .ForMember(d => d.EffectiveDate, s => s.MapFrom(x => x.PolicyEffectiveDate))
                .ForMember(d => d.ExpirationDate, s => s.MapFrom(x => x.PolicyExpirationDate))
                .ForMember(d => d.Number, s => s.MapFrom(x => x.PolicyNumber));

            profileExpression.CreateMap<Claim, PolicyOne.Claim>()
                .ForMember(d => d.ClaimId, s => s.MapFrom(x => x.ClaimId))
                .ForMember(d => d.Number, s => s.MapFrom(x => x.ClaimId))
                .ForMember(d => d.ImportedTimezoneId, s => s.Ignore())
                .ForMember(d => d.LossDate, s => s.MapFrom(x => x.LossDate))
                .ForMember(d => d.ClaimLineOfBusinessType, s => s.MapFrom(x => x.LineOfBusiness))
                .ForMember(d => d.ClaimSource, s => s.Ignore())
                .ForMember(d => d.ReportedDate, s => s.MapFrom(x => x.ReportedDate))
                .ForMember(d => d.ClosedDate, s => s.MapFrom(x => x.ClosedDate))
                .ForMember(d => d.Status, s => s.MapFrom(x => x.ClaimStatus))
                .ForMember(d => d.Description, s => s.MapFrom(x => x.ClaimDescription))
                .ForMember(d => d.AccidentType, s => s.Ignore());

            profileExpression.CreateMap<Feature, PolicyOne.Feature>()
                .ForMember(d => d.Number, s => s.MapFrom(x => x.FeatureId))
                .ForMember(d => d.ClaimFeatureId, s => s.MapFrom(x => x.FeatureId))
                .ForMember(d => d.ClosedDate, s => s.MapFrom(x => x.CloseDate))
                .ForMember(d => d.Coverage, s => s.MapFrom(x => x.CoverageCode))
                .ForMember(d => d.CoverageSubCode, s => s.MapFrom(x => x.CoverageSubCode))
                .ForMember(d => d.OpenDate, s => s.MapFrom(x => x.OpenDate))
                .ForMember(d => d.Status, s => s.MapFrom(x => x.FeatureStatus));

            profileExpression.CreateMap<Claim, Vehicle>()
                .ForMember(d => d.LicenseNumber, s => s.MapFrom(x => x.DriverLicenseId))
                .ForMember(d => d.LicenseState, s => s.MapFrom(x => x.DriverLicenseState))
                .ForMember(d => d.Make, s => s.MapFrom(x => x.InsuredMake))
                .ForMember(d => d.Model, s => s.MapFrom(x => x.InsuredModel))
                .ForMember(d => d.Vin, s => s.MapFrom(x => x.InsuredVin))
                .ForMember(d => d.Year, s => s.MapFrom(x => x.InsuredYear));

            profileExpression.CreateMap<Claim, Claimant>()
                .ForMember(d => d.BusinessName, s => s.Ignore())
                .ForMember(d => d.City, s => s.Ignore())
                .ForMember(d => d.FirstName, s => s.MapFrom(x => x.DriverFirstName))
                .ForMember(d => d.LastName, s => s.MapFrom(x => x.DriverLastName))
                .ForMember(d => d.State, s => s.Ignore());
        }
    }
}