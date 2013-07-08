using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;

namespace GithubClient
{
    /// <summary>
    /// http://developer.github.com/v3/repos/hooks/
    /// </summary>
    public static class RepositoryHookApi
    {
        /// <summary>
        /// List hook on repository
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Hook[]> ListHook(
            this Github github,
            string owner,
            string repo,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoHooks(owner, repo);
            return await github.GetJsonObjectAsync<Hook[]>(addr, cancellationToken);
        }
        /// <summary>
        /// Get hook by id on specified repository
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Hook> GetHook(
            this Github github,
            string owner,
            string repo,
            string id,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoHooksId(owner, repo, id);
            return await github.GetJsonObjectAsync<Hook>(addr, cancellationToken);
        }
        /// <summary>
        /// Create hook on repository
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="name"></param>
        /// <param name="config"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Hook> CreateHook(
            this Github github,
            string owner,
            string repo,
            string name,
            Dictionary<string, string> config,
            Dictionary<string, object> options,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoHooks(owner, repo);
            var postData = new Dictionary<string, object>
                {
                    {"name", name},
                    {"config", config}
                };
            Github.CopyOptions(options,postData);
            return await github.PostJsonIoAsync<Dictionary<string, object>, Hook>(
                addr, postData, cancellationToken);
        }
        /// <summary>
        /// Update hook
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="id"></param>
        /// <param name="updateOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Hook> UpdateHook(
            this Github github,
            string owner,
            string repo,
            string id,
            Dictionary<string, object> updateOptions,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoHooksId(owner, repo, id);
            return await github.PatchJsonIoAsync<Dictionary<string, object>, Hook>(
                addr, updateOptions, cancellationToken);
        }

        /// <summary>
        /// test a push hook
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<bool> TestHook(
            this Github github,
            string owner,
            string repo,
            string id,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoHooksIdTests(owner, repo, id);
            var content = new StringContent("");
            using (var result = await github.PostAsync(addr, content, cancellationToken))
            {
                return result.StatusCode == HttpStatusCode.NoContent;
            }
        }

        public static async Task<bool> DeleteHook(
            this Github github,
            string owner,
            string repo,
            string id,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoHooksId(owner, repo, id);
            return await github.DeleteAsync(addr, HttpStatusCode.NoContent, cancellationToken);
        }
    }
}