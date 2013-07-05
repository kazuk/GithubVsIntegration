using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;
using Newtonsoft.Json;

namespace GithubClient
{
    public static class IssueApi
    {
        public static async Task<Issue[]> ListIssue(
            this Github github,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github!=null);
            Contract.Requires(cancellationToken!=null);

            var responce = await github.GetAsync("issues", cancellationToken);
            var resContent = await responce.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Issue[]>(resContent);
        }
    }
}