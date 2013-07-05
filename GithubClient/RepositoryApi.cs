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

            var addr = ApiAddr.UserRepos();
            return await github.GetJsonObjectAsync<Repository[]>(addr, cancellationToken);
        }

        public static async Task<Repository[]> ListOrgRepository(
            this Github github,
            string org,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.OrgsOrgRepos(org);
            return await github.GetJsonObjectAsync<Repository[]>(addr, cancellationToken);
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
            var addr = ApiAddr.UserRepos();

            return await github.PostJsonIoAsync<Dictionary<string, object>, CreateRepositoryResult>(
                    addr, createParams, cancellationToken);
        }

        public static async Task<bool> DeleteRepository(
            this Github github,
            string ownerUserId,
            string repositoryId,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github != null);
            var apiAddr = ApiAddr.ReposOwnerRepo(ownerUserId, repositoryId);
            return await github.DeleteAsync(apiAddr, HttpStatusCode.NoContent, cancellationToken);
        }
    }
}