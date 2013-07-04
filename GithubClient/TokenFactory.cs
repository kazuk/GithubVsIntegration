using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GithubClient
{
    public class TokenFactory
    {
        private readonly string _apiHost;
        private readonly string _appName;

        public TokenFactory( string apiHost, string appName )
        {
            _apiHost = apiHost;
            _appName = appName;
        }

        public async Task<string> CreateAuthorization(string userName, string password, string[] scopes)
        {
            var createAuthorizationMessage = new {scopes, note = _appName};
            string json = JsonConvert.SerializeObject( createAuthorizationMessage );
            var client = new HttpClient(new UserAgentHandler("GitHubVsIntegrator", new BasicAuthHandler(userName, password)));            
            var res = await client.PostAsync(_apiHost+"/authorizations", new StringContent(json));
            var resContent = await res.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<Authorization>(resContent);

            return obj.token;
        }
    }
}