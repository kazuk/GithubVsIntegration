using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GithubClient.HttpHandlerUtilities
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly string _authToken;
        private readonly string _userAgent;

        public AuthTokenHandler(string authToken, string userAgent )
            : this(authToken, userAgent, new HttpClientHandler())
        {
        }

        public AuthTokenHandler(string authToken, string userAgent, HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            _authToken = authToken;
            _userAgent = userAgent;            
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            request.Headers.Add("user-agent", _userAgent);
            request.Headers.Add("Authorization","token "+_authToken);
            return base.SendAsync(request, cancellationToken);
        }
    }
}