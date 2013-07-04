using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.HttpHandlerUtilities;

namespace GithubClient
{
    public class Github
    {
        private readonly string _apiHost;
        private HttpClient _client;

        public Github(string authToken, string appName, string apiHost)
        {
            _apiHost = apiHost;
            _client = new HttpClient( new AuthTokenHandler(authToken,appName));
        }

        public HttpClient Client
        {
            get { return _client; }
        }

        public string ApiHost
        {
            get { return _apiHost; }
        }

        public async Task<HttpResponseMessage> GetAsync(string apiAddr, CancellationToken cancellationToken)
        {
            var requestUri = string.Format("{0}{1}{2}", ApiHost, (ApiHost.EndsWith("/")? "": "/"), apiAddr);
            var res = await Client.GetAsync(requestUri,cancellationToken);
            return res;
        }
    }
}
