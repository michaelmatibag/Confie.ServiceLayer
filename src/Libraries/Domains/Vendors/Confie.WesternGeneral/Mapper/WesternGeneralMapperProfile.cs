using System;
using System.Linq;
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
                }))
                .ForMember(d => d.Features, s => s.MapFrom(x =>
                {
                    return x.Features.Select(feature => new PolicyOne.Feature
                        {
                            Number = feature.FeatureId,
                            ClaimFeatureId = feature.FeatureId,
                            ClosedDate = new DateTimeOffset(feature.CloseDate),
                            Coverage = feature.CoverageCode,
                            CoverageSubCode = feature.CoverageSubCode,
                            OpenDate = new DateTimeOffset(feature.OpenDate),
                            Status = feature.FeatureStatus,
                            PercentAtFault = x.PercentAtFault,
                            LossDescription = x.ClaimDescription,
                            Claimant = new Claimant
                            {
                                Vehicle = new Vehicle
                                {
                                    Year = x.InsuredYear,
                                    LicenseNumber = x.DriverLicenseId,
                                    Model = x.InsuredModel,
                                    Vin = x.InsuredVin,
                                    Make = x.InsuredMake,
                                    LicenseState = x.DriverLicenseState
                                },
                                State = x.DriverLicenseState,
                                BusinessName = string.Empty,
                                FirstName = x.DriverFirstName,
                                City = string.Empty,
                                LastName = x.DriverLastName
                            },
                            InsuredVehicle = new Vehicle
                            {
                                Year = x.InsuredYear,
                                LicenseNumber = x.DriverLicenseId,
                                Model = x.InsuredModel,
                                Vin = x.InsuredVin,
                                Make = x.InsuredMake,
                                LicenseState = x.DriverLicenseState
                            },
                            Payments = x.PaymentTransactions.Select(paymentTransaction => new Payment
                                {
                                    City = paymentTransaction.PaymentCity,
                                    Address = paymentTransaction.PaymentAddress,
                                    Amount = Convert.ToInt64(paymentTransaction.PaymentAmount),
                                    BusinessName = string.Empty,
                                    CheckNumber = paymentTransaction.CheckNumber,
                                    Date = new DateTimeOffset(paymentTransaction.PaymentDate),
                                    FirstName = x.DriverFirstName,
                                    LastName = x.DriverLastName,
                                    PaymentType = paymentTransaction.PaymentType,
                                    RecoveryType = paymentTransaction.RecoveryType,
                                    State = paymentTransaction.PaymentState,
                                    Status = paymentTransaction.PaymentStatus,
                                    Zip = paymentTransaction.PaymentZip,
                                    PaymentId = paymentTransaction.PaymentTransactionId.ToString()
                                })
                                .ToList(),
                            Reserves = x.ReserveTransactions.Select(reserveTransaction => new Reserve
                                {
                                    Amount = Convert.ToInt64(reserveTransaction.ReserveAfter),
                                    ChangeDate = new DateTimeOffset(reserveTransaction.ReserveChangeDate),
                                    ClaimReserveId = reserveTransaction.ReserveTransactionId.ToString()
                                })
                                .ToList()
                        })
                        .ToList();
                }));
        }
    }
}