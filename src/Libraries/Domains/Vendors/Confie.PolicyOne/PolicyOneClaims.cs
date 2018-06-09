using System.Collections.Generic;
using Newtonsoft.Json;

namespace Confie.PolicyOne
{
    public class PolicyOneClaims
    {
        [JsonProperty("claims")]
        public IList<Claim> Claims { get; set; }
    }
}