using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class Claimant
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("businessName")]
        public string BusinessName { get; set; }

        [JsonProperty("driver")]
        public NamedInsured Driver { get; set; }

        [JsonProperty("vehicle")]
        public Vehicle Vehicle { get; set; }
    }
}