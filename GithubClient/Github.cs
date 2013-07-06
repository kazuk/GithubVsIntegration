using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GithubClient.HttpHandlerUtilities;
using Newtonsoft.Json;

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
            var httpClientHandler = new HttpClientHandler
                {
                    AllowAutoRedirect = false
                };
            _apiHost = apiHost + (apiHost.EndsWith("/")?"":"/");
            _client = new HttpClient( new AuthTokenHandler(authToken,appName,httpClientHandler));
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
        /// <remarks>CacheManagerがcacheEntryを返すようならキャッシュ結果を使います
        /// http://developer.github.com/v3/ 
        /// Conditional requests を参照</remarks>
        public async Task<HttpResponseMessage> GetAsync(string apiAddr, CancellationToken cancellationToken)
        {
            Contract.Requires(apiAddr!=null);
            Contract.Requires(!apiAddr.StartsWith("/"),"apiAddr は / を先頭に持ってはいけない"); 
            Contract.Requires(cancellationToken!=null);

            cancellationToken.ThrowIfCancellationRequested();

            var requestUri = String.Format("{0}{1}", ApiHost, apiAddr);

            var cacheEntry = CacheManager.GetCacheEntry(requestUri);
            if (cacheEntry == null)
            {
                var res = await _client.GetAsync(requestUri, cancellationToken);
                CacheManager.CreateEntry(requestUri, res.Headers.CacheControl, res.Headers.ETag.Tag, await res.Content.ReadAsStringAsync());
                return res;
            }
            else
            {
                var message = new HttpRequestMessage(HttpMethod.Get, requestUri);
                message.Headers.Add("If-None-Match", cacheEntry.ETag); 
                var res = await _client.SendAsync(message, cancellationToken);
                if (res.StatusCode == HttpStatusCode.NotModified)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(cacheEntry.Content)
                        };
                }
                cacheEntry.Content = await res.Content.ReadAsStringAsync();
                cacheEntry.ETag = res.Headers.ETag.Tag;
                CacheManager.UpdateEntry(res.Headers.CacheControl, cacheEntry);
                return res;
            }
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
            string apiAddr,
            HttpContent content,
            CancellationToken cancellationToken)
        {
            Contract.Requires(apiAddr != null);
            Contract.Requires(!apiAddr.StartsWith("/"), "apiAddr は / を先頭に持ってはいけない");
            Contract.Requires(content!=null);
            Contract.Requires(cancellationToken!=null);

            cancellationToken.ThrowIfCancellationRequested();

            var requestUri = String.Format("{0}{1}", ApiHost, apiAddr);
            return await _client.PostAsync(requestUri,content,cancellationToken);
        }

        public async Task<HttpResponseMessage> PutAsync(
            string apiAddr,
            HttpContent content,
            CancellationToken cancellationToken)
        {
            Contract.Requires(apiAddr != null);
            Contract.Requires(!apiAddr.StartsWith("/"), "apiAddr は / を先頭に持ってはいけない");
            Contract.Requires(content != null);
            Contract.Requires(cancellationToken != null);

            cancellationToken.ThrowIfCancellationRequested();

            var requestUri = String.Format("{0}{1}", ApiHost, apiAddr);
            return await _client.PutAsync(requestUri, content, cancellationToken);
        }

        /// <summary>
        /// 指定アドレスから T で示される型のオブジェクトを Json で取得します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiAddr"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<T> GetJsonObjectAsync<T>(
            string apiAddr,
            CancellationToken cancellationToken)
        {
            Contract.Requires(apiAddr != null);
            Contract.Requires(!apiAddr.StartsWith("/"), "apiAddr は / を先頭に持ってはいけない");
            Contract.Requires(cancellationToken != null);

            using (var res = await GetAsync(apiAddr, cancellationToken))
            {
                var content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
        }

        public async Task<TOutput> PostJsonIoAsync<TInput, TOutput>(
            string apiAddr,
            TInput postData,
            CancellationToken cancellationToken) where TInput : class 
        {
            Contract.Requires(apiAddr != null);
            Contract.Requires(!apiAddr.StartsWith("/"), "apiAddr は / を先頭に持ってはいけない");
            Contract.Requires(cancellationToken != null);
            Contract.Requires(postData!=null);

            var jsonText = JsonConvert.SerializeObject(postData);
            var stringContent = new StringContent(jsonText, Encoding.UTF8, "application/json");
            using (var response = await PostAsync(apiAddr, stringContent, cancellationToken))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TOutput>(responseContent);
            }
        }

        /// <summary>
        /// 指定のAPIアドレスに PATCH リクエストでJSONを投げ、応答JSONを解釈して返します
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="apiAddr"></param>
        /// <param name="patchData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TOutput> PatchJsonIoAsync<TInput, TOutput>(string apiAddr,
                                        TInput patchData,
                                        CancellationToken cancellationToken) where TInput : class 
        {
            Contract.Requires(apiAddr != null);
            Contract.Requires(!apiAddr.StartsWith("/"), "apiAddr は / を先頭に持ってはいけない");
            Contract.Requires(cancellationToken != null);
            Contract.Requires(patchData != null);

            var jsonText = JsonConvert.SerializeObject(patchData);
            var stringContent = new StringContent(jsonText, Encoding.UTF8, "application/json");
            using (var response = await PatchAsync(apiAddr, stringContent, cancellationToken))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TOutput>(responseContent);
            }
        }


        /// <summary>
        /// 指定のAPIアドレスに PATCH リクエストを投げ、レスポンスを返します
        /// </summary>
        /// <param name="apiAddr"></param>
        /// <param name="content"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> PatchAsync(string apiAddr,
                                             HttpContent content,
                                             CancellationToken cancellationToken)
        {
            var requestUri = String.Format("{0}{1}", ApiHost, apiAddr);
            return await _client.PatchAsync(requestUri, content, cancellationToken);
        }

        /// <summary>
        /// 指定のAPIアドレスに DELETE リクエストを投げ、レスポンスを返します
        /// </summary>
        /// <param name="apiAddr"></param>
        /// <param name="content"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> DeleteAsync(string apiAddr,
                                             HttpContent content,
                                             CancellationToken cancellationToken)
        {
            var requestUri = String.Format("{0}{1}", ApiHost, apiAddr);
            return await _client.DeleteAsync(requestUri, content, cancellationToken);
        }
        /// <summary>
        /// 指定のAPIアドレスにDELETEリクエストを投げ、ステータスコードを確認します
        /// </summary>
        /// <param name="apiAddr"></param>
        /// <param name="expectedStatusCode"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(
            string apiAddr,
            HttpStatusCode expectedStatusCode,
            CancellationToken cancellationToken)
        {
            Contract.Requires(apiAddr != null);
            Contract.Requires(!apiAddr.StartsWith("/"), "apiAddr は / を先頭に持ってはいけない");
            Contract.Requires(cancellationToken != null);

            using (var result = await DeleteAsync(apiAddr, cancellationToken))
            {
                return result.StatusCode == expectedStatusCode;
            }
        }

        /// <summary>
        /// 指定のAPIアドレスにPUTリクエストを投げ、ステータスコードを確認します
        /// </summary>
        /// <param name="apiAddr"></param>
        /// <param name="content"></param>
        /// <param name="expectedStatusCode"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> PutAsync(string apiAddr,
                                                 HttpContent content,
                                                 HttpStatusCode expectedStatusCode,
                                                 CancellationToken cancellationToken)
        {
            Contract.Requires(apiAddr != null);
            Contract.Requires(!apiAddr.StartsWith("/"), "apiAddr は / を先頭に持ってはいけない");
            Contract.Requires(cancellationToken != null);
            Contract.Requires(content!=null);

            using (var res = await PutAsync(apiAddr, content, cancellationToken))
            {
                return res.StatusCode == expectedStatusCode;
            }
        }

        /// <summary>
        /// 指定のAPIアドレスに PUT リクエストでJSONを投げ、応答JSONを解釈して返します
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="apiAddr"></param>
        /// <param name="putData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TOutput> PutJsonIoAsync<TInput, TOutput>(string apiAddr,
                                TInput putData,
                                 CancellationToken cancellationToken) where TInput : class
        {
            Contract.Requires(apiAddr != null);
            Contract.Requires(!apiAddr.StartsWith("/"), "apiAddr は / を先頭に持ってはいけない");
            Contract.Requires(cancellationToken != null);
            Contract.Requires(putData != null);

            var jsonText = JsonConvert.SerializeObject(putData);
            var stringContent = new StringContent(jsonText, Encoding.UTF8, "application/json");
            using (var response = await PutAsync(apiAddr, stringContent, cancellationToken))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TOutput>(responseContent);
            }
        }

        /// <summary>
        /// 指定のAPIアドレスに PUT リクエストでJSONを投げ、応答JSONを解釈して返します
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="apiAddr"></param>
        /// <param name="putData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TOutput> DeleteJsonIoAsync<TInput, TOutput>(string apiAddr,
                                TInput putData,
                                 CancellationToken cancellationToken) where TInput : class
        {
            Contract.Requires(apiAddr != null);
            Contract.Requires(!apiAddr.StartsWith("/"), "apiAddr は / を先頭に持ってはいけない");
            Contract.Requires(cancellationToken != null);
            Contract.Requires(putData != null);

            var jsonText = JsonConvert.SerializeObject(putData);
            var stringContent = new StringContent(jsonText, Encoding.UTF8, "application/json");
            using (var response = await DeleteAsync(apiAddr, stringContent, cancellationToken))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TOutput>(responseContent);
            }
        }

        public static void CopyOptions(
            IEnumerable<KeyValuePair<string, object>> source,
            IDictionary<string, object> copyTo)
        {
            if (source == null) return;
            foreach (var option in source)
            {
                copyTo.Add(option.Key, option.Value);
            }
        }

        /// <summary>
        /// 指定の apiAddr から HTTP 302 応答の Locationを取得します
        /// </summary>
        /// <param name="apiAddr"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> GetLocationAsync(string apiAddr,
                                             CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var requestUri = String.Format("{0}{1}", ApiHost, apiAddr);
            using (var result = await _client.GetAsync(requestUri, cancellationToken))
            {
                return result.StatusCode==HttpStatusCode.Found 
                    ? result.Headers.Location.ToString() 
                    : "";
            }
        }
    }
}
