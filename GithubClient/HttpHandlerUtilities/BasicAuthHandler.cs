using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace GithubClient.HttpHandlerUtilities
{
    internal class BasicAuthHandler : DelegatingHandler
    {
        private readonly string _username;
        private readonly string _password;

        public BasicAuthHandler(string username, string password)
            : this(username, password, new HttpClientHandler())
        {
        }

        public BasicAuthHandler(string username, string password, HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            _username = username;
            _password = password;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = CreateBasicHeader();

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }

        public AuthenticationHeaderValue CreateBasicHeader()
        {
            var byteArray = System.Text.Encoding.UTF8.GetBytes(_username + ":" + _password);
            var base64String = Convert.ToBase64String(byteArray);
            return new AuthenticationHeaderValue("Basic", base64String);
        }
    }
}