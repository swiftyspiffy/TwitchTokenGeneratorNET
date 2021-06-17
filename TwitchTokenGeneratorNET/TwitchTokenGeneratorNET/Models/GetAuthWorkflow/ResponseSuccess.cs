using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwitchTokenGeneratorNET.Models.GetAuthWorkflow
{
    public class ResponseSuccess : IResponse
    {
        [JsonProperty(PropertyName = "scopes")]
        public string[] Scopes { protected set; get; }
        [JsonProperty(PropertyName = "token")]
        public string Token { protected set; get; }
        [JsonProperty(PropertyName = "username")]
        public string Username { protected set; get; }
        [JsonProperty(PropertyName = "user_id")]
        public string Userid { protected set; get; }
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { protected set; get; }
    }
}
