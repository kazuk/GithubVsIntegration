using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.HttpHandlerUtilities;

namespace GithubClient
{
    public class Github
    {
        private readonly string _apiHost;
        private readonly HttpClient _client;
        private static readonly IReadOnlyDictionary<string, object> _emptyDictionary = 
            new ReadOnlyDictionary<string, object>(new Dictionary<string, object>());

        public Github(string authToken, string appName, string apiHost)
        {
            Contract.Requires(authToken!=null);
            Contract.Requires(appName!=null);
            Contract.Requires(apiHost!=null);

            _apiHost = apiHost + (apiHost.EndsWith("/")?"":"/");
            _client = new HttpClient( new AuthTokenHandler(authToken,appName));
        }

        /// <summary>
        /// 
        /// </summary>
        // TODO: APIメソッド実装中に HttpClient に触りたくなった時に使う踏み台、最終的には削除する
        [Obsolete("踏み台踏まずにできるようになろうね")]
        public HttpClient Client
        {
            /* APIメソッド内で Client を触る所を十分にパラメタライズして 
             * Extract Method で切り出し static メソッドが切り出されなければ
             * パラメタライズが甘い
             * 
             * static メソッドを Move リファクタを使って Github クラスへ移動
             * リファクタで Make method non-static して Github クラスのAPI 化する。
             */
            get { return _client; }
        }

        public string ApiHost
        {
            get { return _apiHost; }
        }

        /// <summary>
        /// オプションパラメータが無い場合に使われる空のディクショナリ
        /// </summary>
        public static IReadOnlyDictionary<string, object> EmptyDictionary
        {
            get { return _emptyDictionary; }
        }

        /// <summary>
        /// 指定の apiAddr にGETリクエストを投げます。
        /// </summary>
        /// <param name="apiAddr"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string apiAddr, CancellationToken cancellationToken)
        {
            Contract.Requires(apiAddr!=null);
            Contract.Requires(!apiAddr.StartsWith("/"),"apiAddr は / を先頭に持ってはいけない"); 
            Contract.Requires(cancellationToken!=null);

            cancellationToken.ThrowIfCancellationRequested();

            var requestUri = String.Format("{0}{1}", ApiHost, apiAddr);
            var res = await _client.GetAsync(requestUri, cancellationToken);
            return res;
        }

        /// <summary>
        /// 指定の apiAddr にDELETEリクエストを投げます
        /// </summary>
        /// <param name="apiAddr"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteAsync(string apiAddr, CancellationToken cancellationToken)
        {
            Contract.Requires(apiAddr != null);
            Contract.Requires(!apiAddr.StartsWith("/"), "apiAddr は / を先頭に持ってはいけない");
            Contract.Requires(cancellationToken != null);

            cancellationToken.ThrowIfCancellationRequested();

            var requestUri = String.Format("{0}{1}", ApiHost, apiAddr);
            return await _client.DeleteAsync(requestUri, cancellationToken);
        }

        public async Task<HttpResponseMessage> PostAsync(
            string apiAdder,
            HttpContent content,
            CancellationToken cancellationToken)
        {
            Contract.Requires(apiAdder!=null);
            Contract.Requires(!apiAdder.StartsWith("/"), "apiAddr は / を先頭に持ってはいけない");
            Contract.Requires(content!=null);
            Contract.Requires(cancellationToken!=null);

            cancellationToken.ThrowIfCancellationRequested();

            var requestUri = String.Format("{0}{1}", ApiHost, apiAdder);
            return await _client.PostAsync(requestUri,content,cancellationToken);
        }
    }
}
