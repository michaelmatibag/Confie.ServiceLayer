using System;
using System.Collections.Generic;
using FileHelpers;
using FileHelpers.Events;

namespace Confie.WesternGeneral
{
    [FixedLengthRecord]
    public class Feature : INotifyRead
    {
        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string ClaimId { get; set; }

        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string FeatureId { get; set; }

        [FieldFixedLength(18)]
        [FieldConverter(ConverterKind.Date, "yyyy/MM/dd hh:mmtt")]
        public DateTime OpenDate { get; set; }

        [FieldFixedLength(18)]
        [FieldNullValue(typeof(DateTime), "1/1/1753 12:00:00 AM")]
        [FieldConverter(ConverterKind.Date, "yyyy/MM/dd hh:mmtt")]
        public DateTime CloseDate { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string FeatureStatus { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string CoverageCode { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string CoverageSubCode { get; set; }

        [FieldFixedLength(1)]
        [FieldConverter(ConverterKind.Boolean)]
        public bool ClosedWithoutPayment { get; set; }

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
        public string UpdatedUser { get; set; }

        [FieldHidden]
        public DateTime UpdatedDate { get; set; }

        [FieldHidden]
        public virtual Claim Claim { get; set; }

        [FieldHidden]
        public virtual IList<PaymentTransaction> PaymentTransactions { get; set; }

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