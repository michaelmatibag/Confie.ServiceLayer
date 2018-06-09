using System.Collections.Generic;
using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class PolicyOneClaims
    {
        [JsonProperty("claims")]
        public List<Claim> Claims { get; set; }
    }
}