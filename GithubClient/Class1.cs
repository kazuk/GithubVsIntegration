using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GithubClient
{
    class Class1
    {
    }

    public class TokenFactory
    {
        private string _apiHost = "https://api.github.com";
        private string _appName = "githubvsintegrations";

        public TokenFactory()
        {
        }

        public async Task CreateAuthorization(string userName, string password, string[] scopes)
        {


            var createAuthorizationMessage = new {scopes, note = _appName};
            string json = JsonConvert.SerializeObject( createAuthorizationMessage );
            var client = new HttpClient(new UserAgentHandler("GitHubVsIntegrator", new BasicAuthHandler(userName, password)));            
            var res = await client.PostAsync(_apiHost+"/authorizations", new StringContent(json));
            var resContent = await res.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject(resContent);
            
        }
    }
}
