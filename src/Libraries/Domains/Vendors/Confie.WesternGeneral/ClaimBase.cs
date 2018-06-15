using System;
using FileHelpers;

namespace Confie.WesternGeneral
{
    public abstract class ClaimBase
    {
        [FieldHidden]
        public string UpdatedUser { get; set; }

        [FieldHidden]
        public DateTime UpdatedDate { get; set; }
    }
}