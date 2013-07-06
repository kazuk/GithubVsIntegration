using System.Diagnostics.Contracts;

namespace GithubClient
{
    /// <summary>
    /// キャッシュに対するストレージが提供しなければならないインターフェースです
    /// </summary>
    [ContractClass(typeof(CacheProviderContract))]
    public interface ICacheProvider
    {
        /// <summary>
        /// キャッシュ要素を登録します
        /// </summary>
        /// <param name="cacheEntry"></param>
        void CreateEntry(CacheEntry cacheEntry);

        /// <summary>
        /// キャッシュ要素の取得
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns>存在しない場合 null </returns>
        CacheEntry GetEntry(string requestUri);

        /// <summary>
        /// 指定URIのキャッシュを削除します
        /// </summary>
        /// <param name="requestUri"></param>
        /// <remarks>
        /// 指定URIへのリクエスト結果が NoCache で返された場合に呼び出されます。
        /// キャッシュ要素はすでに古いですが、更新すべきキャッシュデータがありません。
        /// </remarks>
        void RemoveEntry(string requestUri);

        /// <summary>
        /// キャッシュ要素を更新します
        /// </summary>
        /// <param name="cacheEntry"></param>
        void UpdateEntry(CacheEntry cacheEntry);
    }

    [ContractClassFor(typeof(ICacheProvider))]
    public abstract class CacheProviderContract : ICacheProvider
    {
        public void CreateEntry(CacheEntry cacheEntry)
        {
            Contract.Requires(cacheEntry!=null);
        }

        public CacheEntry GetEntry(string requestUri)
        {
            Contract.Requires(requestUri!=null);
            return null;
        }

        public void RemoveEntry(string requestUri)
        {
            Contract.Requires(requestUri!=null);
        }

        public void UpdateEntry(CacheEntry cacheEntry)
        {
            Contract.Requires(cacheEntry!=null);
        }
    }
}