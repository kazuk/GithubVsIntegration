using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GithubClient.HttpHandlerUtilities
{
    internal class UserAgentHandler : DelegatingHandler
    {
        private readonly string _userAgent;
        public UserAgentHandler(string userAgent)
            : this(userAgent,new HttpClientHandler())
        {
            
        }

        public UserAgentHandler(string userAgent, HttpMessageHandler httpClientHandler) : base(httpClientHandler)
        {
            _userAgent = userAgent;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("user-agent",_userAgent);
            return base.SendAsync(request, cancellationToken);
        }
    }
}