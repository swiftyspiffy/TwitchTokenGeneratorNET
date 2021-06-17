using System;
using Newtonsoft.Json;

namespace TwitchTokenGeneratorNET.Models.RefreshToken
{
    public class RefreshTokenResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { protected set; get; }
        [JsonProperty(PropertyName = "token")]
        public string Token { protected set; get; }
        [JsonProperty(PropertyName = "refresh")]
        public string Refresh { protected set; get; }
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { protected set; get; }
    }
}
