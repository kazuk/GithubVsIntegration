using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GithubClient.Tests
{
    [TestClass]
    public class TokenFactoryTest
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            const string apiHost = "https://api.github.com";
            const string appName = "githubvsintegrations";
            var tokenFactory = new TokenFactory(apiHost, appName);
            var token = await tokenFactory.CreateAuthorization(
                TokensEtc.UserName, TokensEtc.Password, new[] {"public_repo"});
            token.IsNotNull();

            // API 一個呼べればトークン取得は正しいだろう
            var github = new Github(token, "githubvsintegrations", apiHost);
            var cancellationToken = new CancellationToken();
            var repos = await github.ListUserRepository(cancellationToken);
            repos.IsNotNull();
        }
    }
}
