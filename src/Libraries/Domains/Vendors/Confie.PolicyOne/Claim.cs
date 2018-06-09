using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class Claim
    {
        [JsonProperty("incidentDriver")]
        public IncidentDriver IncidentDriver { get; set; }

        [JsonProperty("insuredDriver")]
        public InsuredDriver InsuredDriver { get; set; }

        [JsonProperty("namedInsured")]
        public NamedInsured NamedInsured { get; set; }

        [JsonProperty("policy")]
        public Policy Policy { get; set; }

        [JsonProperty("claimId")]
        public string ClaimId { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("importedTimezoneId")]
        public long ImportedTimezoneId { get; set; }

        [JsonProperty("lossDate")]
        public DateTimeOffset LossDate { get; set; }

        [JsonProperty("claimLineOfBusinessType")]
        public string ClaimLineOfBusinessType { get; set; }

        [JsonProperty("claimSource")]
        public string ClaimSource { get; set; }

        [JsonProperty("reportedDate")]
        public DateTimeOffset ReportedDate { get; set; }

        [JsonProperty("closedDate")]
        public DateTimeOffset ClosedDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("accidentType")]
        public string AccidentType { get; set; }

        [JsonProperty("features")]
        public IList<Feature> Features { get; set; }
    }
}