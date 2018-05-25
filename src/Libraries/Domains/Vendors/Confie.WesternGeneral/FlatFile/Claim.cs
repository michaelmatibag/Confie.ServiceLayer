using System;
using FileHelpers;

namespace Confie.WesternGeneral.FlatFile
{
    [FixedLengthRecord(FixedMode.AllowLessChars)]
    [IgnoreEmptyLines]
    public class Claim
    {
        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string ClaimId { get; set; }

        [FieldFixedLength(18)]
        [FieldConverter(ConverterKind.Date, "yyyy/MM/dd hh:mmtt")]
        public DateTime LossDate { get; set; }

        [FieldFixedLength(18)]
        [FieldConverter(ConverterKind.Date, "yyyy/MM/dd hh:mmtt")]
        public DateTime ReportedDate { get; set; }

        [FieldFixedLength(18)]
        [FieldNullValue(typeof(DateTime), "0001/01/01 12:00AM")]
        [FieldConverter(ConverterKind.Date, "yyyy/MM/dd hh:mmtt")]
        public DateTime ClosedDate { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string ClaimStatus { get; set; }

        [FieldFixedLength(1)]
        [FieldConverter(ConverterKind.Boolean)]
        public bool ClosedWithoutPayment { get; set; }

        [FieldFixedLength(3)]
        [FieldConverter(ConverterKind.Int32)]
        public int PercentAtFault { get; set; }

        [FieldFixedLength(100)]
        [FieldTrim(TrimMode.Right)]
        public string ClaimDescription { get; set; }

        [FieldFixedLength(18)]
        [FieldConverter(ConverterKind.Date, "yyyy/MM/dd hh:mmtt")]
        public DateTime PolicyEffectiveDate { get; set; }

        [FieldFixedLength(18)]
        [FieldConverter(ConverterKind.Date, "yyyy/MM/dd hh:mmtt")]
        public DateTime PolicyExpirationDate { get; set; }

        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        public string PolicyNumber { get; set; }

        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)]
        public string LineOfBusiness { get; set; }

        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string DriverLastName { get; set; }

        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string DriverFirstName { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string DriverLicenseId { get; set; }

        [FieldFixedLength(2)]
        public string DriverLicenseState { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string InsuredVin { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string InsuredMake { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string InsuredModel { get; set; }

        [FieldFixedLength(4)]
        [FieldConverter(ConverterKind.Int32)]
        public int InsuredYear { get; set; }

        [FieldFixedLength(17)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal Payments { get; set; }

        [FieldFixedLength(17)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal Recoveries { get; set; }

        [FieldFixedLength(17)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal Expenses { get; set; }

        [FieldFixedLength(17)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal ReservesAtBeginning { get; set; }

        [FieldFixedLength(17)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal ReservesAtEnd { get; set; }

        [FieldFixedLength(17)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal TotalIncurredLoss { get; set; }
    }
}