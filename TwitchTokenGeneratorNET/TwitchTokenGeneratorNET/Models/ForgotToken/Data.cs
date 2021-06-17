using System;
using Newtonsoft.Json;

namespace TwitchTokenGeneratorNET.Models.ForgotToken
{
    public class Data
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { protected set; get; }
        [JsonProperty(PropertyName = "userid")]
        public string Userid { protected set; get; }
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { protected set; get; }
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { protected set; get; }
        [JsonProperty(PropertyName = "scopes")]
        public string[] Scopes { protected set; get; }
    }
}
