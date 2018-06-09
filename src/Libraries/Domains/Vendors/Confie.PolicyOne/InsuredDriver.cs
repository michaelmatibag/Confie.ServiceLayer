using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class InsuredDriver
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("licenseNumber")]
        public string LicenseNumber { get; set; }

        [JsonProperty("licenseState")]
        public string LicenseState { get; set; }

        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}