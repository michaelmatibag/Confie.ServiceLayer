using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class Vehicle
    {
        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("year")]
        public long Year { get; set; }

        [JsonProperty("vin")]
        public string Vin { get; set; }

        [JsonProperty("licenseNumber")]
        public string LicenseNumber { get; set; }

        [JsonProperty("licenseState")]
        public string LicenseState { get; set; }
    }
}