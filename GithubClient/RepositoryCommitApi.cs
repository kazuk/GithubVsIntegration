using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;

namespace GithubClient
{
    public static class RepositoryCommitApi
    {
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


    }
}