using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;
using Newtonsoft.Json;

namespace GithubClient
{
    public static class RepositoryApi
    {
        
        public static async Task<Repository[]> ListUserRepository(
            this Github github,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github != null);
            Contract.Requires(cancellationToken != null);

            const string userRepos = "user/repos";
            return await github.GetJsonObjectAsync<Repository[]>(userRepos, cancellationToken);
        }

        public static async Task<CreateRepositoryResult> CreateRepository(
            this Github github,
            string name,
            IReadOnlyDictionary<string, object> createOptions,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github != null);
            Contract.Requires(name != null);
            Contract.Requires(cancellationToken != null);
            var createParams = new Dictionary<string, object>
                {
                    {"name", name},
                };
            Github.CopyOptions(createOptions, createParams);
            const string apiAdder = "user/repos";

            return await github.PostJsonIoAsync<Dictionary<string, object>, CreateRepositoryResult>(
                    apiAdder, createParams, cancellationToken);
        }

        public static async Task<bool> DeleteRepository(
            this Github github,
            int ownerUserId,
            int repositoryId,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github != null);
            string apiAddr = string.Format("repos/{0}/{1}", ownerUserId, repositoryId);
            return await github.DeleteAsync(apiAddr, HttpStatusCode.NoContent, cancellationToken);
        }
    }
}