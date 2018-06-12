using System;
using FileHelpers;
using FileHelpers.Events;

namespace Confie.WesternGeneral
{
    [FixedLengthRecord]
    public class ReserveTransaction : INotifyRead
    {
        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string ClaimId { get; set; }

        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string FeatureId { get; set; }

        [FieldFixedLength(18)]
        [FieldConverter(ConverterKind.Date, "yyyy/MM/dd hh:mmtt")]
        public DateTime ReserveChangeDate { get; set; }

        [FieldFixedLength(17)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal ReserveBefore { get; set; }

        [FieldFixedLength(17)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal ReserveAfter { get; set; }

        [FieldFixedLength(20)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Dummy { get; set; }

        [FieldHidden]
        public int ReserveTransactionId { get; set; }

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