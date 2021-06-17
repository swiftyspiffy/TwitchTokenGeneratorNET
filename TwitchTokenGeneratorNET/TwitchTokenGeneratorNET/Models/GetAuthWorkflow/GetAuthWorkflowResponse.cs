using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwitchTokenGeneratorNET.Models.GetAuthWorkflow
{
    public class GetAuthWorkflowResponse
    {
        public bool Success { protected set; get; }
        public string Id { protected set; get; }
        public IResponse Response { protected set; get; }

        internal GetAuthWorkflowResponse(string jsonStr)
        {
            JObject json = JObject.Parse(jsonStr);
            Success = bool.Parse(json["success"].ToString());
            Id = json["id"].ToString();
            if(Success)
            {
                Response = JsonConvert.DeserializeObject<ResponseSuccess>(jsonStr);
            } else
            {
                Response = JsonConvert.DeserializeObject<ResponseFailed>(jsonStr);
            }
        }
    }
}
