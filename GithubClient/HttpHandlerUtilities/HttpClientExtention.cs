using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GithubClient.HttpHandlerUtilities
{
    public static class HttpClientExtention
    {
        private static readonly HttpMethod _patchMethod = new HttpMethod("PATCH");

        public static async Task<HttpResponseMessage> PatchAsync(
            this HttpClient client,
            string requestUri,
            HttpContent content,
            CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(_patchMethod, requestUri)
                {
                    Content = content
                };
            return await client.SendAsync(request, cancellationToken);
        }
    }
}
