using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class IncidentDriver
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("licenseNumber")]
        public string LicenseNumber { get; set; }

        [JsonProperty("licenseState")]
        public string LicenseState { get; set; }
    }
}