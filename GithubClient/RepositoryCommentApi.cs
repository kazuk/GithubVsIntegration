using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;

namespace GithubClient
{
    /// <summary>
    /// http://developer.github.com/v3/repos/comments/
    /// </summary>
    public static class RepositoryCommentApi
    {
        /// <summary>
        /// list comment on repository
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repository"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Comment[]> ListComments(
            this Github github,
            string owner,
            string repository,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github!=null);
            Contract.Requires(owner!=null);
            Contract.Requires(repository!=null);
            Contract.Requires(cancellationToken!=null);

            var addr = ApiAddr.ReposOwnerRepoComments(owner, repository);
            return await github.GetJsonObjectAsync<Comment[]>(addr, cancellationToken);
        }

        /// <summary>
        /// list comment on commit
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repository"></param>
        /// <param name="commit"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Comment[]> ListCommentsOnCommit(
            this Github github,
            string owner,
            string repository,
            string commit,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github!=null);
            Contract.Requires(owner!=null);
            Contract.Requires(repository!=null);
            Contract.Requires(commit!=null);
            Contract.Requires(cancellationToken!=null);

            var addr = ApiAddr.ReposOwnerRepoCommitsShaComments(owner, repository, commit);
            return await github.GetJsonObjectAsync<Comment[]>(addr, cancellationToken);
        }

        /// <summary>
        /// create comment
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repository"></param>
        /// <param name="commit"></param>
        /// <param name="body"></param>
        /// <param name="commitOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Comment> CreateComment(
            this Github github,
            string owner,
            string repository,
            string commit,
            string body,
            IReadOnlyDictionary<string, object> commitOptions,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github != null);
            Contract.Requires(owner != null);
            Contract.Requires(repository != null);
            Contract.Requires(commit != null);
            Contract.Requires(body != null);
            var comment = new Dictionary<string, object>
                {
                    {"body", body},
                };
            Github.CopyOptions(commitOptions, comment);
            var apiAddr = ApiAddr.ReposOwnerRepoCommitsShaComments(owner, repository, commit);
            return await github.PostJsonIoAsync<Dictionary<string, object>, Comment>(
                apiAddr, comment, cancellationToken);
        }

        /// <summary>
        /// get single comment
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repository"></param>
        /// <param name="commentId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Comment> GetComment(
            this Github github,
            string owner,
            string repository,
            string commentId,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github!=null);
            Contract.Requires(owner!=null);
            Contract.Requires(repository!=null);
            Contract.Requires(commentId!=null);
            Contract.Requires(cancellationToken != null);
            var apiAddr = FormatCommentAddr(owner, repository, commentId);
            return await github.GetJsonObjectAsync<Comment>(apiAddr, cancellationToken);
        }

        /// <summary>
        /// update comment
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repository"></param>
        /// <param name="commentId"></param>
        /// <param name="body"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Comment> UpdateComment(
            this Github github,
            string owner,
            string repository,
            string commentId,
            string body,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github != null);
            Contract.Requires(owner != null);
            Contract.Requires(repository != null);
            Contract.Requires(commentId != null);
            Contract.Requires(body!=null);
            Contract.Requires(cancellationToken!=null);
            var comment = new Dictionary<string, object>
                {
                    {"body", body},
                };
            var apiAddr = FormatCommentAddr(owner, repository, commentId);
            return await github.PatchJsonIoAsync<Dictionary<string, object>, Comment>(
                apiAddr, comment, cancellationToken);
        }


        /// <summary>
        /// delete specified comment
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repository"></param>
        /// <param name="commentId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteComment(
            this Github github,
            string owner,
            string repository,
            string commentId,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github != null);
            Contract.Requires(owner != null);
            Contract.Requires(repository != null);
            Contract.Requires(commentId != null);
            Contract.Requires(cancellationToken != null);
            var apiAddr = FormatCommentAddr(owner, repository, commentId);
            return await github.DeleteAsync(apiAddr, HttpStatusCode.NoContent, cancellationToken);
        }

        private static string FormatCommentAddr(
            string owner,
            string repository,
            string commentId)
        {
            var apiAddr = ApiAddr.ReposOwnerRepoCommentsId(owner, repository, commentId);
            return apiAddr;
        }
    }
}