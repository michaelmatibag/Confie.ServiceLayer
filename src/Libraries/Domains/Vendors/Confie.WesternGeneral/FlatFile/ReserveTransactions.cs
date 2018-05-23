using System;
using FileHelpers;

namespace Confie.WesternGeneral.FlatFile
{
    public class ReserveTransactions
    {
        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string ClaimId { get; set; }

        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Right)]
        public string FeatureId { get; set; }

        [FieldFixedLength(18)]
        [FieldConverter(ConverterKind.Date)]
        public DateTime ReserveChangeDate { get; set; }

        [FieldFixedLength(17)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal ReserveBefore { get; set; }

        [FieldFixedLength(17)]
        [FieldConverter(ConverterKind.Decimal)]
        public decimal ReserveAfter { get; set; }
    }
}