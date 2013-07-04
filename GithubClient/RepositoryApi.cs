using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;
using Newtonsoft.Json;

namespace GithubClient
{
    public static class RepositoryApi
    {
        public static async Task<Repository[]> ListUserRepository( this Github github, CancellationToken cancellationToken)
        {
            const string userRepos = "user/repos";
            var res = await github.GetAsync(userRepos,cancellationToken);
            var content = await res.Content.ReadAsStringAsync();
            var repository = JsonConvert.DeserializeObject<Repository[]>(content);
            return repository;
        }
    }
}