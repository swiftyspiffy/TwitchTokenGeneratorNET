using System;
using Newtonsoft.Json;

namespace TwitchTokenGeneratorNET.Models.GetSupportedScopes
{
    public class Scope
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { protected set; get; }
        [JsonProperty(PropertyName = "scope")]
        public string ScopeString { protected set; get; }
        [JsonProperty(PropertyName = "desc")]
        public string Description { protected set; get; }

        public override string ToString()
        {
            return $"Id: {Id}, Scope: {ScopeString}, Description: {Description}";
        }
    }
}
