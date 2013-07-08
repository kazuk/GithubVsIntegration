using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;

namespace GithubClient
{
    /// <summary>
    /// http://developer.github.com/v3/repos/commits/
    /// </summary>
    public static class RepositoryCommitApi
    {
        /// <summary>
        /// List commits on a repository
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Commit[]> ListCommitsOnRepository(
            this Github github,
            string owner,
            string repo,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github!=null);
            Contract.Requires(owner!=null);
            Contract.Requires(repo!=null);
            Contract.Requires(cancellationToken!=null);

            var addr = ApiAddr.ReposOwnerRepoCommits(owner, repo);
            return await github.GetJsonObjectAsync<Commit[]>(addr, cancellationToken);
        }

        /// <summary>
        /// Get a single commit
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="sha"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Commit> GetCommit(
            this Github github,
            string owner,
            string repo,
            string sha,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github!=null);
            Contract.Requires(owner!=null);
            Contract.Requires(repo!=null);
            Contract.Requires(cancellationToken!=null);

            var addr = ApiAddr.ReposOwnerRepoCommitsSha(owner, repo, sha);
            return await github.GetJsonObjectAsync<Commit>(addr, cancellationToken);
        }

        /// <summary>
        /// Compare two commits
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="baseCommit"></param>
        /// <param name="headCommit"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<CompareCommitResult> CompareCommit(
            this Github github,
            string owner,
            string repo,
            string baseCommit,
            string headCommit,
            CancellationToken cancellationToken)
        {
            var addr = ApiAddr.ReposOwnerRepoCompareBase(owner, repo, baseCommit) + "..." + headCommit;
            return await github.GetJsonObjectAsync<CompareCommitResult>(addr, cancellationToken);
        }
    }
}