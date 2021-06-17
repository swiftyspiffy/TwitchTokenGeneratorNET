using System;
using Newtonsoft.Json;

namespace TwitchTokenGeneratorNET.Models.CreateRequest
{
    public class CreateRequestResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success;
        [JsonProperty(PropertyName = "message")]
        public string Message;
    }
}
