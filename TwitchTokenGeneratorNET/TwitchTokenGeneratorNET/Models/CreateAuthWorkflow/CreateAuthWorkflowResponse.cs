using System;
using Newtonsoft.Json;

namespace TwitchTokenGeneratorNET.Models.CreateAuthWorkflow
{
    public class CreateAuthWorkflowResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { protected set; get; }
        [JsonProperty(PropertyName = "id")]
        public string Id { protected set; get; }
        [JsonProperty(PropertyName = "message")]
        public string Message { protected set; get; }
    }
}
