using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GithubClient.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            const string apiHost = "https://api.github.com";
            const string appName = "githubvsintegrations";
            var tokenFactory = new TokenFactory(apiHost, appName);
            var token = await tokenFactory.CreateAuthorization(
                TokensEtc.UserName, TokensEtc.Password, new[] {"public_repo"});

        }
    }

    public partial class TokensEtc
    {
        static partial void Configure();

        public static string UserName;
        public static string Password;
        public static string AccessToken;

        static TokensEtc()
        {
            Configure();
        }
    }
}
