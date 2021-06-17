using System;
using Newtonsoft.Json;

namespace TwitchTokenGeneratorNET.Models.ForgotToken
{
    public class ForgotResponse
    {
        [JsonProperty(PropertyName = "result")]
        public string Result { protected set; get; }
        [JsonProperty(PropertyName = "data")]
        public Data Data { protected set; get; }
    }
}
