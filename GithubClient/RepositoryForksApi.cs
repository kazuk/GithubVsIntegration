using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;

namespace GithubClient
{
    /// <summary>
    /// http://developer.github.com/v3/repos/forks/
    /// </summary>
    public static class RepositoryForksApi
    {
        public static async Task<Repository[]> ListForks(
            this Github github,
            string owner,
            string repo,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoForks(owner, repo);
            return await github.GetJsonObjectAsync<Repository[]>(addr, cancellationToken);
        }

        public static async Task<Repository> CreateFork(
            this Github github,
            string owner,
            string repo,
            IReadOnlyDictionary<string,object> createForkOptions,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoForks(owner, repo);
            var createForkParam = new Dictionary<string, object>();
            Github.CopyOptions(createForkOptions,createForkParam);
            return await github.PostJsonIoAsync<Dictionary<string, object>, Repository>
                             (addr, createForkParam, cancellationToken);
        }
    }
}