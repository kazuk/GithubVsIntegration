using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;

namespace GithubClient
{
    /// <summary>
    /// http://developer.github.com/v3/repos/keys/
    /// </summary>
    public static class RepositoryDeployKeysApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<DeployKey[]> ListDeployKey(
            this Github github,
            string owner,
            string repo,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoKeys(owner, repo);
            return await github.GetJsonObjectAsync<DeployKey[]>(addr, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="title"></param>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<DeployKey> CreateDeployKey(
            this Github github,
            string owner,
            string repo,
            string title,
            string key,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoKeys(owner, repo);
            var postData= new Dictionary<string, string>
                {
                    {"title",title},
                    {"key",key}
                };
            return await github.PostJsonIoAsync<Dictionary<string, string>, DeployKey>(
                addr, postData, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<DeployKey> UpdateDeployKey(
            this Github github,
            string owner,
            string repo,
            string id,
            string title,
            string key,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoKeysId(owner, repo, id);
            var patchData = new Dictionary<string, string>
                {
                    {"title", title},
                    {"key", key}
                };
            return await github.PatchJsonIoAsync<Dictionary<string, string>, DeployKey>(
                addr, patchData, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteDeployKey(
            this Github github,
            string owner,
            string repo,
            string id,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoKeysId(owner, repo, id);
            return await github.DeleteAsync(addr, HttpStatusCode.NoContent, cancellationToken);
        }
    }
}