using System;
using System.Collections.Generic;
using FileHelpers;
using FileHelpers.Events;

namespace Confie.WesternGeneral
{
    [FixedLengthRecord]
    public class Claim : INotifyRead
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
        [FieldNullValue(typeof(DateTime), "1/1/1753 12:00:00 AM")]
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

        [FieldFixedLength(19)]
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

        [FieldHidden]
        public SubmissionStatus SubmissionStatus { get; set; }

        [FieldHidden]
        public string UpdatedUser { get; set; }

        [FieldHidden]
        public DateTime UpdatedDate { get; set; }

        [FieldHidden]
        public virtual List<Feature> Features { get; set; }

        [FieldHidden]
        public virtual List<PaymentTransaction> PaymentTransactions { get; set; }

        [FieldHidden]
        public virtual List<ReserveTransaction> ReserveTransactions { get; set; }

        public void BeforeRead(BeforeReadEventArgs e)
        {
            e.SkipThisRecord = string.IsNullOrWhiteSpace(e.RecordLine) || e.RecordLine.Equals("\u001a");
        }

        public void AfterRead(AfterReadEventArgs e)
        {
            //Do nothing.
        }
    }
}