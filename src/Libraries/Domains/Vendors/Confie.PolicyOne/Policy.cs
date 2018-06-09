using System;
using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class Policy
    {
        [JsonProperty("effectiveDate")]
        public DateTimeOffset EffectiveDate { get; set; }

        [JsonProperty("expirationDate")]
        public DateTimeOffset ExpirationDate { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }
}