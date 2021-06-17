using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwitchTokenGeneratorNET.Models.GetAuthWorkflow
{
    public class ResponseFailed : IResponse
    {
        [JsonProperty(PropertyName = "error")]
        public int Error { protected set; get; }
        [JsonProperty(PropertyName = "message")]
        public string Message { protected set; get; }
    }
}
