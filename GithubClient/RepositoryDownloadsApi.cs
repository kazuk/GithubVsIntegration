using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;

namespace GithubClient
{
    /// <summary>
    /// http://developer.github.com/v3/repos/downloads/
    /// </summary>
    public static class RepositoryDownloadsApi
    {
        public static async Task<Download[]> ListDownloads(
            this Github github,
            string owner,
            string repo,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoDownloads(owner, repo);
            return await github.GetJsonObjectAsync<Download[]>(addr, cancellationToken);
        }
        public static async Task<Download> GetDownload(
            this Github github,
            string owner,
            string repo,
            string id,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoDownloadsId(owner, repo, id);
            return await github.GetJsonObjectAsync<Download>(addr, cancellationToken);
        }
        public static async Task<CreateDownloadResult> CreateDownload(
            this Github github,
            string owner,
            string repo,
            string name,
            long size,
            IReadOnlyDictionary<string, object> createDownloadOptions,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoDownloads(owner, repo);
            var createParam = new Dictionary<string, object>
                {
                    {"name", name},
                    {"size", size}
                };
            Github.CopyOptions(createDownloadOptions,createParam);
            return await github.PostJsonIoAsync<Dictionary<string, object>, CreateDownloadResult>(
                addr, createParam, cancellationToken);
        }

        public static async Task<bool> PutDownloadFile(
            this Github github,
            CreateDownloadResult createDownloadResult,
            Stream fileContent,
            CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var content = new MultipartFormDataContent
                {
                    {new StringContent(createDownloadResult.path), "key"},
                    {new StringContent(createDownloadResult.acl), "acl"},
                    {new StringContent("201"), "success_action_status"},
                    {new StringContent(createDownloadResult.name), "Filename"},
                    {new StringContent(createDownloadResult.accesskeyid), "AWSAccessKeyId"},
                    {new StringContent(createDownloadResult.policy), "policy"},
                    {new StringContent(createDownloadResult.signature), "Signature"},
                    {new StringContent(createDownloadResult.mime_type), "Content-Type"},
                    new StreamContent(fileContent)
                };
            using (var postResult = await client.PostAsync(createDownloadResult.s3_url, content, cancellationToken))
            {
                return postResult.StatusCode == HttpStatusCode.Created;
            }
        }

        public static async Task<bool> CreateDownloadAndPutFile(
            this Github github,
            string owner,
            string repo,
            string name,
            Stream stream,
            IReadOnlyDictionary<string, object> createDownloadOptions,
            CancellationToken cancellationToken)
        {
            var createDownloadResult = await github.CreateDownload(
                owner, repo, name, stream.Length, createDownloadOptions, cancellationToken);
            return await github.PutDownloadFile(createDownloadResult, stream, cancellationToken);
        }

        public static async Task<bool> DeleteDownload(
            this Github github,
            string owner,
            string repo,
            string id,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoDownloadsId(owner, repo, id);
            return await github.DeleteAsync(addr, HttpStatusCode.NoContent, cancellationToken);
        }
    }
}