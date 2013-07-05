using System;
using System.Diagnostics.Contracts;
using System.Net.Http.Headers;

namespace GithubClient
{
    /// <summary>
    /// CacheProvider を保持し、CacheProvider が無い場合の非キャッシュな
    /// デフォルト動作を提供します。
    /// </summary>
    public class CacheManager
    {
        private static ICacheProvider _cacheProvider;

        /// <summary>
        /// 現在のキャッシュプロバイダを返します
        /// </summary>
        public static ICacheProvider CacheProvider
        {
            get { return _cacheProvider; }
        }

        /// <summary>
        /// キャッシュプロバイダを設定します
        /// </summary>
        /// <param name="cacheProvider"></param>
        /// <remarks>キャッシュプロバイダは一度しか設定できません。</remarks>
        public static void SetCacheProvider(ICacheProvider cacheProvider)
        {
            Contract.Requires(cacheProvider!=null);
            Contract.Requires(CacheProvider==null);
            Contract.Ensures(CacheProvider!=null);
            _cacheProvider = cacheProvider;
        }

        /// <summary>
        /// キャッシュから requestUri の要素を取得します
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public static CacheEntry GetCacheEntry(string requestUri)
        {
            Contract.Requires(requestUri!=null);

            if (CacheProvider == null) return null;
            return CacheProvider.GetEntry(requestUri);
        }

        /// <summary>
        /// cacheControl ヘッダ値によりキャッシュ要素を作成、登録します。
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="cacheControl"></param>
        /// <param name="eTag"></param>
        /// <param name="content"></param>
        public static void CreateEntry(string requestUri,
                                       CacheControlHeaderValue cacheControl,
                                       string eTag,
                                       string content)
        {
            Contract.Requires(requestUri!=null);
            Contract.Requires(cacheControl!=null);
            Contract.Requires(eTag!=null);
            Contract.Requires(content!=null);

            if(CacheProvider==null) return;

            if( cacheControl.NoCache ) return;
            CacheProvider.CreateEntry(
                new CacheEntry
                    {
                        RequestUri = requestUri,
                        Content = content,
                        ETag = eTag,
                        ExpireAt = DateTime.UtcNow.Add(cacheControl.MaxAge ?? TimeSpan.FromSeconds(60))
                    });
        }

        /// <summary>
        /// cacheEntry 要素を更新します
        /// </summary>
        /// <param name="cacheControl"></param>
        /// <param name="cacheEntry"></param>
        public static void UpdateEntry(CacheControlHeaderValue cacheControl,
                                       CacheEntry cacheEntry)
        {
            Contract.Requires(cacheControl!=null);
            Contract.Requires(cacheEntry!=null);

            if(CacheProvider==null) return;

            if (cacheControl.NoCache)
            {
                CacheProvider.RemoveEntry(cacheEntry.RequestUri);
            }
            else
            {
                cacheEntry.ExpireAt = DateTime.UtcNow.Add(cacheControl.MaxAge ?? TimeSpan.FromSeconds(60));
                CacheProvider.UpdateEntry(cacheEntry);
            }
        }
    }
}