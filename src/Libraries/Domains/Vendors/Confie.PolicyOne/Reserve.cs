using System;
using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class Reserve
    {
        [JsonProperty("claimReserveId")]
        public string ClaimReserveId { get; set; }

        [JsonProperty("changeDate")]
        public DateTimeOffset ChangeDate { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }
    }
}