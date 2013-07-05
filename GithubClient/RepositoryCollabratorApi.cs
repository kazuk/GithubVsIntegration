using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.Models;
using Newtonsoft.Json;

namespace GithubClient
{
    /// <summary>
    /// implements repository collaborators API
    /// http://developer.github.com/v3/repos/collaborators/
    /// </summary>
    public static class RepositoryCollabratorApi
    {
        /// <summary>
        /// list collaborator in specified repository
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repository"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Collaborator[]> ListRepositoryCollaborator(
            this Github github,
            string owner,
            string repository,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github!=null);
            Contract.Requires(cancellationToken!=null);
            Contract.Requires(owner!=null);
            Contract.Requires(repository!=null);

            const string apiAddrFormat = "repos/{0}/{1}/collaborators";
            var apiAddr = string.Format(apiAddrFormat, owner, repository);
            return await github.GetJsonObjectAsync<Collaborator[]>(apiAddr, cancellationToken);
        }

        /// <summary>
        /// add collaborator to repository
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repository"></param>
        /// <param name="collaboratorUser"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<bool> AddRepositoryCollaborator(
            this Github github,
            string owner,
            string repository,
            string collaboratorUser,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github!=null);
            Contract.Requires(owner!=null);
            Contract.Requires(repository!=null);
            Contract.Requires(collaboratorUser!=null);
            Contract.Requires(cancellationToken != null);
            
            var apiAddr = GetCollaboratorAddress(owner, repository, collaboratorUser);
            HttpContent stringContent = new StringContent("");
            return await github.PutAsync(apiAddr, stringContent, HttpStatusCode.NoContent, cancellationToken);
        }

        private static string GetCollaboratorAddress(
            string owner,
            string repository,
            string collaboratorUser)
        {
            const string apiAddrFormat = "repos/{0}/{1}/collaborators/{2}";
            var apiAddr = string.Format(apiAddrFormat, owner, repository, collaboratorUser);
            return apiAddr;
        }

        /// <summary>
        /// remove collaborator from repository
        /// </summary>
        /// <param name="github"></param>
        /// <param name="owner"></param>
        /// <param name="repository"></param>
        /// <param name="collaboratorUser"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<bool> RemoveRepositoryCollaborator(
            this Github github,
            string owner,
            string repository,
            string collaboratorUser,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github!=null);
            Contract.Requires(owner!=null);
            Contract.Requires(repository!=null);
            Contract.Requires(collaboratorUser!=null);
            Contract.Requires(cancellationToken!=null);

            var apiAddr = GetCollaboratorAddress(owner, repository, collaboratorUser);
            return await github.DeleteAsync(apiAddr, HttpStatusCode.NoContent, cancellationToken);
        }
    }
}