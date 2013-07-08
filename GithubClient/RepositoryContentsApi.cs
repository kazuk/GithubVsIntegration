using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;
using Newtonsoft.Json;

namespace GithubClient
{
    /// <summary>
    /// http://developer.github.com/v3/repos/contents/
    /// </summary>
    public static class RepositoryContentsApi
    {
        /// <summary>
        /// Get the README
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Content> GetReadme(
            this Github github,
            string owner,
            string repo,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoReadme(owner, repo);
            return await github.GetJsonObjectAsync<Content>(addr, cancellationToken);
        }

        /// <summary>
        /// Get contents
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="path"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Content[]> GetContents(
            this Github github,
            string owner,
            string repo,
            string path,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoContentsPath(owner, repo, path);
            using (var result = await github.GetAsync(addr, cancellationToken))
            {
                var contentText = await result.Content.ReadAsStringAsync();
                if (contentText.StartsWith("["))
                {
                    return JsonConvert.DeserializeObject<Content[]>(contentText);
                }
                return new[]
                    {
                        JsonConvert.DeserializeObject<Content>(contentText)
                    };
            }
        }

        /// <summary>
        /// Create a file
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="path"></param>
        /// <param name="message"></param>
        /// <param name="content"></param>
        /// <param name="createFileOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<FileEditResult> CreateFile(
            this Github github,
            string owner,
            string repo,
            string path,
            string message,
            string content,
            IReadOnlyDictionary<string, object> createFileOptions,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoContentsPath(owner, repo, path);
            var fileParams = new Dictionary<string, object>
                {
                    {"message", message},
                    {"content", content}
                };
            Github.CopyOptions(createFileOptions, fileParams);
            return await github.PutJsonIoAsync<Dictionary<string, object>, FileEditResult>(
                addr, fileParams, cancellationToken);
        }

        /// <summary>
        /// Update a file
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="path"></param>
        /// <param name="message"></param>
        /// <param name="content"></param>
        /// <param name="sha"></param>
        /// <param name="updateFileOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<FileEditResult> UpdateFile(
            this Github github,
            string owner,
            string repo,
            string path,
            string message,
            string content,
            string sha,
            IReadOnlyDictionary<string, object> updateFileOptions,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoContentsPath(owner, repo, path);
            var fileParams = new Dictionary<string, object>
                {
                    {"message", message},
                    {"content", content},
                    {"sha", sha}
                };
            Github.CopyOptions(updateFileOptions, fileParams);
            return await github.PutJsonIoAsync<Dictionary<string, object>, FileEditResult>(
                addr, fileParams, cancellationToken);
        }

        /// <summary>
        /// Delete a file
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="path"></param>
        /// <param name="message"></param>
        /// <param name="sha"></param>
        /// <param name="deleteFileOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<FileEditResult> DeleteFile(
            this Github github,
            string owner,
            string repo,
            string path,
            string message,
            string sha,
            IReadOnlyDictionary<string, object> deleteFileOptions,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoContentsPath(owner, repo, path);
            var fileParams = new Dictionary<string, object>
                {
                    {"message", message},
                    {"sha", sha}
                };
            Github.CopyOptions(deleteFileOptions, fileParams);
            return await github.DeleteJsonIoAsync<Dictionary<string, object>, FileEditResult>(
                addr, fileParams, cancellationToken);
        }

        /// <summary>
        /// Get archive link
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="archiveFormat"></param>
        /// <param name="reference"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<string> GetArchiveLink(
            this Github github,
            string owner,
            string repo,
            string archiveFormat,
            string reference,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoArchive_formatRef(owner, repo, archiveFormat, reference);
            return await github.GetLocationAsync(addr, cancellationToken);
        }
    }
}