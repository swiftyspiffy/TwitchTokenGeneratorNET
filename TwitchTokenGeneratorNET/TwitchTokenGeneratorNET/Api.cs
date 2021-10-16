using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using TwitchTokenGeneratorNET.Models.CreateAuthWorkflow;
using TwitchTokenGeneratorNET.Models.CreateQuickLink;
using TwitchTokenGeneratorNET.Models.CreateRequest;
using TwitchTokenGeneratorNET.Models.ForgotToken;
using TwitchTokenGeneratorNET.Models.GetAuthWorkflow;
using TwitchTokenGeneratorNET.Models.GetSupportedScopes;
using TwitchTokenGeneratorNET.Models.RefreshToken;

namespace TwitchTokenGeneratorNET
{
    public static class Api
    {
        private const string BaseUrl = "https://twitchtokengenerator.com/";

        public static CreateAuthWorkflowResponse CreateAuthWorkflow(string applicationTitle, List<string> scopes, string additionalArgs = "")
        {
            return ReqGet<CreateAuthWorkflowResponse>($"api/create/{Base64Encode(applicationTitle)}/{String.Join('+', (scopes))}{additionalArgs}");
        }

        public static GetAuthWorkflowResponse GetAuthWorkflow(string authWorkflowId, string additionalArgs = "")
        {
            return ReqGet<GetAuthWorkflowResponse>($"api/status/{authWorkflowId}{additionalArgs}");
        }

        public static ForgotResponse ForgotToken(string accessToken, string additionalArgs = "")
        {
            return ReqGet<ForgotResponse>($"api/forgot/{accessToken}{additionalArgs}");
        }

        public static RefreshTokenResponse RefreshToken(string refreshToken, string additionalArgs = "")
        {
            return ReqGet<RefreshTokenResponse>($"api/refresh/{refreshToken}{additionalArgs}");
        }

        public static GetSupportedScopesResponse GetSupportedScopes(string additionalArgs = "")
        {
            return ReqGet<GetSupportedScopesResponse>($"api/scopes{additionalArgs}");
        }

        public static CreateQuickLinkResponse CreateQuickLink(List<string> scopes, bool authenticateImmediately, string additionalArgs = "")
        {
            var supportedScopes = GetSupportedScopes();
            var allSupportedScopes = new List<Scope>();
            allSupportedScopes.AddRange(supportedScopes.Helix);
            allSupportedScopes.AddRange(supportedScopes.V5);

            var scopeIds = new List<string>();
            foreach(var scope in scopes)
            {
                var supportedScope = allSupportedScopes.FirstOrDefault(x => x.ScopeString.ToLower() == scope.ToLower());
                if (supportedScope == null)
                {
                    throw new Exception("Scope not supported: " + scope);
                }
                scopeIds.Add(supportedScope.Id.ToString());
            }

            return ReqGet<CreateQuickLinkResponse>($"quick/create/{String.Join('+', scopeIds)}/{(authenticateImmediately ? "auth_auth" : "auth_stay")}{additionalArgs}");
        }

        public static CreateRequestResponse CreateRequest(List<string> scopes, string username, string email, string additionalArgs = "")
        {
            return ReqPost<CreateRequestResponse>($"request/create.php{additionalArgs}", new Dictionary<string, string>
            {
                {
                    "scopes", String.Join('+', scopes)
                },
                {
                    "my_name", username
                },
                {
                    "my_email", email
                }
            });
        }

        private static string Base64Encode(string input)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static T ReqGet<T>(string path)
        {
            var wc = new WebClient();
            wc.Headers.Add("user-agent", "TTGNET");
            var jsonStr = wc.DownloadString($"{BaseUrl}{path}");

            // get auth flow is a special case that needs to be populated manually
            Type type = typeof(T);
            if(type == typeof(GetAuthWorkflowResponse))
            {
                return (T)Convert.ChangeType(new GetAuthWorkflowResponse(jsonStr), typeof(T));
            } else
            {
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }

            
        }

        private static T ReqPost<T>(string path, Dictionary<string, string> body)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("TTGNET", Assembly.GetExecutingAssembly().GetName().Version.ToString()));
            var content = new FormUrlEncodedContent(body);
            var response = client.PostAsync($"{BaseUrl}{path}", content).GetAwaiter().GetResult();

            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
