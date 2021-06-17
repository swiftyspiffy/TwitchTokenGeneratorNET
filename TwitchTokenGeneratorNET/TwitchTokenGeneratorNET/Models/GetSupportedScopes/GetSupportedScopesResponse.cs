using System;
using Newtonsoft.Json;

namespace TwitchTokenGeneratorNET.Models.GetSupportedScopes
{
    public class GetSupportedScopesResponse
    {
        [JsonProperty(PropertyName = "v5")]
        public Scope[] V5;
        [JsonProperty(PropertyName = "helix")]
        public Scope[] Helix;
    }
}
