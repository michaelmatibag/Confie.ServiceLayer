using System;
using FileHelpers;
using FileHelpers.Events;

namespace Confie.WesternGeneral
{
    [FixedLengthRecord]
    public class PaymentTransaction : INotifyRead
    {
        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string ClaimId { get; set; }

        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string FeatureId { get; set; }

        [FieldFixedLength(18)]
        [FieldConverter(ConverterKind.Date, "yyyy/MM/dd hh:mmtt")]
        public DateTime PaymentDate { get; set; }

        [FieldFixedLength(17)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal PaymentAmount { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string PaymentStatus { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string PaymentType { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string RecoveryType { get; set; }

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)]
        public string CheckNumber { get; set; }

        [FieldFixedLength(100)]
        [FieldTrim(TrimMode.Right)]
        public string PaymentAddress { get; set; }

        [FieldFixedLength(100)]
        [FieldTrim(TrimMode.Right)]
        public string PaymentCity { get; set; }

        [FieldFixedLength(2)]
        public string PaymentState { get; set; }

        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Right)]
        public string PaymentZip { get; set; }

        [FieldFixedLength(20)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Dummy { get; set; }

        [FieldHidden]
        public int PaymentTransactionId { get; set; }

        [FieldHidden]
        public string UpdatedUser { get; set; }

        [FieldHidden]
        public DateTime UpdatedDate { get; set; }

        [FieldHidden]
        public virtual Claim Claim { get; set; }

        [FieldHidden]
        public virtual Feature Feature { get; set; }

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