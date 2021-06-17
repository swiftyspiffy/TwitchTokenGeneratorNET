using System;
using System.Collections.Generic;
using TwitchTokenGeneratorNET.Models.GetAuthWorkflow;

namespace TwitchTokenGeneratorNETExample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"TwitchTokenGeneratorNET Example/Test Console Application");
            TestCreateAuthFlow();
            TestGetAuthFlow();
            TestCreateQuickLink();
            TestCreateRequest();
            TestForgotToken();
            TestGetSupportedScopes();
            TestRefreshToken();
        }

        private static void TestCreateAuthFlow()
        {
            Console.WriteLine($"[TestCreateAuthFlow] Application Name?");
            var appNameIn = Console.ReadLine();
            Console.WriteLine($"[TestCreateAuthFlow] Scopes (space separated)?");
            var scopesIn = Console.ReadLine();

            var scopes = new List<string>();
            scopes.AddRange(scopesIn.Split(' '));

            var resp = TwitchTokenGeneratorNET.Api.CreateAuthWorkflow(appNameIn, scopes);
            Console.WriteLine($"[CreateAuthFlow] Response:\n - Id: {resp.Id}\n - Message: {resp.Message}\n - Success: {resp.Success}");
        }

        private static void TestGetAuthFlow()
        {
            Console.WriteLine($"[TestGetAuthFlow] Auth flow id?");
            var authFlowId = Console.ReadLine();

            var resp = TwitchTokenGeneratorNET.Api.GetAuthWorkflow(authFlowId);
            if(resp.Success)
            {
                ResponseSuccess success = (ResponseSuccess)resp.Response;
                Console.WriteLine($"[TestGetAuthFlow] Response:\n - Id: {resp.Id}\n Success: {resp.Success}\n - Client Id: {success.ClientId}\n - Scopes: {String.Join(", ", success.Scopes)}\n - Token: {success.Token}\n - Userid: {success.Userid}\n - Username: {success.Username}");
            } else
            {
                ResponseFailed failed = (ResponseFailed)resp.Response;
                Console.WriteLine($"[TestGetAuthFlow] Response:\n - Id: {resp.Id}\n Success: {resp.Success}\n - Error: {failed.Error}\n - Message: {failed.Message}");
            }
        }

        private static void TestCreateQuickLink()
        {
            Console.WriteLine($"[TestCreateQuickLink] Scopes (space separated)?");
            var scopesIn = Console.ReadLine();

            var scopes = new List<string>();
            scopes.AddRange(scopesIn.Split(' '));

            Console.WriteLine($"[TestCreateQuickLink] Authenticate immediately (0 or 1)?");
            bool authImmediately = Console.ReadLine() == "1";

            var resp = TwitchTokenGeneratorNET.Api.CreateQuickLink(scopes, authImmediately);
            Console.WriteLine($"[TestCreateQuickLink] Response:\n - Success: {resp.Success}\n - Message: {resp.Message}");
        }

        private static void TestCreateRequest()
        {
            Console.WriteLine($"[TestCreateRequest] Scopes (space separated)?");
            var scopesIn = Console.ReadLine();

            var scopes = new List<string>();
            scopes.AddRange(scopesIn.Split(' '));

            Console.WriteLine($"[TestCreateRequest] Your username?");
            var username = Console.ReadLine();

            Console.WriteLine($"[TestCreateRequest] Your email?");
            var email = Console.ReadLine();

            var resp = TwitchTokenGeneratorNET.Api.CreateRequest(scopes, username, email);
            Console.WriteLine($"[TestCreateRequest] Response:\n - Success: {resp.Success}\n - Message: {resp.Message}");
        }

        private static void TestForgotToken()
        {
            Console.WriteLine($"[TestForgotToken] Your oauth access token?");
            var accessToken = Console.ReadLine();

            var resp = TwitchTokenGeneratorNET.Api.ForgotToken(accessToken);
            Console.WriteLine($"[TestForgotToken] Response:\n - Result: {resp.Result}\n - CreatedAt: {resp.Data.CreatedAt}\n - Scopes: {String.Join(", ", resp.Data.Scopes)}\n - UpdatedAt: {resp.Data.UpdatedAt}\n - Userid: {resp.Data.Userid}\n - Username: {resp.Data.Username}");
        }

        private static void TestGetSupportedScopes()
        {
            var resp = TwitchTokenGeneratorNET.Api.GetSupportedScopes();
            foreach(var v5Scope in resp.V5)
            {
                Console.WriteLine($"[TestGetSupportedScopes][v5]: {v5Scope.ToString()}");
            }
            foreach(var helixScope in resp.Helix)
            {
                Console.WriteLine($"[TestGetSupportedScopes][helix]: {helixScope.ToString()}");
            }
        }

        private static void TestRefreshToken()
        {
            Console.WriteLine($"[TestRefreshToken] Your oauth refresh token?");
            var refreshToken = Console.ReadLine();

            var resp = TwitchTokenGeneratorNET.Api.RefreshToken(refreshToken);
            Console.WriteLine($"[TestRefreshToken] Response:\n - Success: {resp.Success}\n - Client ID: {resp.ClientId}\n - Refresh: {resp.Refresh}\n Token: {resp.Token}");
        }
    }
}
