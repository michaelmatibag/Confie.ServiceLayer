using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class NamedInsured
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("streetAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string StreetAddress { get; set; }
    }
}