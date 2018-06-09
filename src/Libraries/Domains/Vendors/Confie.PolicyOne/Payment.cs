using System;
using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class Payment
    {
        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("recoveryType")]
        public string RecoveryType { get; set; }

        [JsonProperty("checkNumber")]
        public string CheckNumber { get; set; }

        [JsonProperty("businessName")]
        public string BusinessName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }
    }
}