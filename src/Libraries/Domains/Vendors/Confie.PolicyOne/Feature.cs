using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class Feature
    {
        [JsonProperty("claimFeatureId")]
        public string ClaimFeatureId { get; set; }

        [JsonProperty("openDate")]
        public DateTimeOffset OpenDate { get; set; }

        [JsonProperty("closedDate")]
        public DateTimeOffset ClosedDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("coverage")]
        public string Coverage { get; set; }

        [JsonProperty("coverageSubCode")]
        public string CoverageSubCode { get; set; }

        [JsonProperty("percentAtFault")]
        public long PercentAtFault { get; set; }

        [JsonProperty("lossDescription")]
        public string LossDescription { get; set; }

        [JsonProperty("claimant")]
        public Claimant Claimant { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("insuredVehicle")]
        public Vehicle InsuredVehicle { get; set; }

        [JsonProperty("payments")]
        public List<Payment> Payments { get; set; }

        [JsonProperty("reserves")]
        public List<Reserve> Reserves { get; set; }
    }
}