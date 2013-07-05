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
            using (var res = await github.GetAsync(userRepos, cancellationToken))
            {
                var content = await res.Content.ReadAsStringAsync();
                var repository = JsonConvert.DeserializeObject<Repository[]>(content);
                return repository;
            }
        }

        public static async Task<CreateRepositoryResult> CreateRepository(
            this Github github,
            string name,
            IReadOnlyDictionary<string, object> createOptions,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github != null);
            Contract.Requires(name != null);
            Contract.Requires(cancellationToken!=null);
            var createParams = new Dictionary<string, object>
                {
                    {"name", name},
                };
            CopyOptions(createOptions, createParams);
            var jsonText = JsonConvert.SerializeObject(createParams);
            const string apiAdder = "user/repos";
            var stringContent = new StringContent(jsonText, System.Text.Encoding.UTF8, "application/json");
            var response = await github.PostAsync(apiAdder, stringContent,cancellationToken);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateRepositoryResult>(responseContent);
        }

        private static void CopyOptions(
            IEnumerable<KeyValuePair<string, object>> createOptions,
            IDictionary<string, object> createParams)
        {
            if (createOptions == null) return;
            foreach (var option in createOptions)
            {
                createParams.Add(option.Key, option.Value);
            }
        }

        public static async Task<bool> DeleteRepository(
            this Github github,
            int ownerUserId,
            int repositoryId,
            CancellationToken cancellationToken)
        {
            Contract.Requires(github != null);
            string apiAddr = string.Format("repos/{0}/{1}", ownerUserId, repositoryId);
            using (var result = await github.DeleteAsync(apiAddr, cancellationToken))
            {
                return result.StatusCode == HttpStatusCode.NoContent;
            }
        }
    }
}