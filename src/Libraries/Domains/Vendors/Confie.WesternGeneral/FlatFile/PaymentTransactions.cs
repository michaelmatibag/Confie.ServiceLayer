using System;
using FileHelpers;

namespace Confie.WesternGeneral.FlatFile
{
    public class PaymentTransactions
    {
        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string ClaimId { get; set; }

        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string FeatureId { get; set; }

        [FieldFixedLength(18)]
        [FieldConverter(ConverterKind.Date)]
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

        [FieldFixedLength(50)]
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
    }
}