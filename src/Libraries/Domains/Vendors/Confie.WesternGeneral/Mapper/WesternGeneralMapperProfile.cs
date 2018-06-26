using System;
using AutoMapper;
using Confie.Infrastructure.Mapper;
using Confie.PolicyOne;

namespace Confie.WesternGeneral.Mapper
{
    public class WesternGeneralMapperProfile : IMapperProfile
    {
        public void Initialize(IProfileExpression profileExpression)
        {
            profileExpression.CreateMap<Claim, PolicyOne.Claim>()
                .ForMember(d => d.ClaimId, s => s.MapFrom(x => x.ClaimId))
                .ForMember(d => d.Number, s => s.MapFrom(x => x.ClaimId))
                .ForMember(d => d.ImportedTimezoneId, s => s.Ignore())
                .ForMember(d => d.LossDate, s => s.MapFrom(x => new DateTimeOffset(x.LossDate)))
                .ForMember(d => d.ClaimLineOfBusinessType, s => s.MapFrom(x => x.LineOfBusiness))
                .ForMember(d => d.ClaimSource, s => s.Ignore())
                .ForMember(d => d.ReportedDate, s => s.MapFrom(x => new DateTimeOffset(x.ReportedDate)))
                .ForMember(d => d.ClosedDate, s => s.MapFrom(x => new DateTimeOffset(x.ClosedDate)))
                .ForMember(d => d.Status, s => s.MapFrom(x => x.ClaimStatus))
                .ForMember(d => d.Description, s => s.MapFrom(x => x.ClaimDescription))
                .ForMember(d => d.AccidentType, s => s.Ignore())
                .ForMember(d => d.IncidentDriver, s => s.MapFrom(x => new IncidentDriver
                {
                    LicenseNumber = x.DriverLicenseId,
                    FirstName = x.DriverFirstName,
                    LastName = x.DriverLastName,
                    LicenseState = x.DriverLicenseState
                }))
                .ForMember(d => d.InsuredDriver, s => s.MapFrom(x => new InsuredDriver
                {
                    LicenseNumber = x.DriverLicenseId,
                    State = x.DriverLicenseState,
                    StreetAddress = string.Empty,
                    FirstName = x.DriverFirstName,
                    City = string.Empty,
                    LastName = x.DriverLastName,
                    LicenseState = x.DriverLicenseState
                }))
                .ForMember(d => d.NamedInsured, s => s.MapFrom(x => new NamedInsured
                {
                    State = x.DriverLicenseState,
                    StreetAddress = string.Empty,
                    FirstName = x.DriverFirstName,
                    City = string.Empty,
                    LastName = x.DriverLastName
                }))
                .ForMember(d => d.Policy, s => s.MapFrom(x => new Policy
                {
                    Number = x.PolicyNumber,
                    ExpirationDate = x.PolicyExpirationDate,
                    EffectiveDate = x.PolicyEffectiveDate
                }));

            profileExpression.CreateMap<Feature, PolicyOne.Feature>()
                .ForMember(d => d.Number, s => s.MapFrom(x => x.FeatureId))
                .ForMember(d => d.ClaimFeatureId, s => s.MapFrom(x => x.FeatureId))
                .ForMember(d => d.ClosedDate, s => s.MapFrom(x => new DateTimeOffset(x.CloseDate)))
                .ForMember(d => d.Coverage, s => s.MapFrom(x => x.CoverageCode))
                .ForMember(d => d.CoverageSubCode, s => s.MapFrom(x => x.CoverageSubCode))
                .ForMember(d => d.OpenDate, s => s.MapFrom(x => new DateTimeOffset(x.OpenDate)))
                .ForMember(d => d.Status, s => s.MapFrom(x => x.FeatureStatus))
                .ForMember(d => d.PercentAtFault, s => s.MapFrom(x => x.Claim.PercentAtFault))
                .ForMember(d => d.LossDescription, s => s.MapFrom(x => x.Claim.ClaimDescription))
                .ForMember(d => d.Claimant, s => s.MapFrom(x => new Claimant
                {
                    Vehicle = new Vehicle
                    {
                        Year = x.Claim.InsuredYear,
                        LicenseNumber = x.Claim.DriverLicenseId,
                        Model = x.Claim.InsuredModel,
                        Vin = x.Claim.InsuredVin,
                        Make = x.Claim.InsuredMake,
                        LicenseState = x.Claim.DriverLicenseState
                    },
                    State = x.Claim.DriverLicenseState,
                    BusinessName = string.Empty,
                    FirstName = x.Claim.DriverFirstName,
                    City = string.Empty,
                    LastName = x.Claim.DriverLastName
                }))
                .ForMember(d => d.InsuredVehicle, s => s.MapFrom(x => new Vehicle
                {
                    Year = x.Claim.InsuredYear,
                    LicenseNumber = x.Claim.DriverLicenseId,
                    Model = x.Claim.InsuredModel,
                    Vin = x.Claim.InsuredVin,
                    Make = x.Claim.InsuredMake,
                    LicenseState = x.Claim.DriverLicenseState
                }))
                .ForMember(d => d.Payments, s => s.MapFrom(x => x.PaymentTransactions))
                .ForMember(d => d.Reserves, s => s.MapFrom(x => x.ReserveTransactions));

            profileExpression.CreateMap<PaymentTransaction, Payment>()
                .ForMember(d => d.City, s => s.MapFrom(x => x.PaymentCity))
                .ForMember(d => d.Address, s => s.MapFrom(x => x.PaymentAddress))
                .ForMember(d => d.Amount, s => s.MapFrom(x => x.PaymentAmount))
                .ForMember(d => d.BusinessName, s => s.Ignore())
                .ForMember(d => d.CheckNumber, s => s.MapFrom(x => x.CheckNumber))
                .ForMember(d => d.Date, s => s.MapFrom(x => new DateTimeOffset(x.PaymentDate)))
                .ForMember(d => d.FirstName, s => s.MapFrom(x => x.Claim.DriverFirstName))
                .ForMember(d => d.LastName, s => s.MapFrom(x => x.Claim.DriverLastName))
                .ForMember(d => d.PaymentType, s => s.MapFrom(x => x.PaymentType))
                .ForMember(d => d.RecoveryType, s => s.MapFrom(x => x.RecoveryType))
                .ForMember(d => d.State, s => s.MapFrom(x => x.PaymentState))
                .ForMember(d => d.Status, s => s.MapFrom(x => x.PaymentStatus))
                .ForMember(d => d.Zip, s => s.MapFrom(x => x.PaymentZip))
                .ForMember(d => d.PaymentId, s => s.MapFrom(x => x.PaymentTransactionId));

            profileExpression.CreateMap<ReserveTransaction, Reserve>()
                .ForMember(d => d.Amount, s => s.MapFrom(x => x.ReserveAfter))
                .ForMember(d => d.ChangeDate, s => s.MapFrom(x => new DateTimeOffset(x.ReserveChangeDate)))
                .ForMember(d => d.ClaimReserveId, s => s.MapFrom(x => x.ReserveTransactionId));
        }
    }
}