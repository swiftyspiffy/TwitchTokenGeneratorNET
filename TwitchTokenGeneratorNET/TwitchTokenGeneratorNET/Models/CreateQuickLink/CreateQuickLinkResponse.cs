using System;
using Newtonsoft.Json;

namespace TwitchTokenGeneratorNET.Models.CreateQuickLink
{
    public class CreateQuickLinkResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success;
        [JsonProperty(PropertyName = "message")]
        public string Message;
    }
}
