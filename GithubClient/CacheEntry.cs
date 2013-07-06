using System;
using System.Diagnostics.Contracts;

namespace GithubClient
{
    /// <summary>
    /// キャッシュ要素を表現します
    /// </summary>
    public class CacheEntry
    {
        private readonly string _requestUri;
        private string _eTag;
        private string _content;

        public CacheEntry(string requestUri)
        {
            Contract.Requires(requestUri!=null);

            _requestUri = requestUri;
        }
        /// <summary>
        /// 要素の取得元URI
        /// </summary>
        public string RequestUri
        {
            get { return _requestUri; }
        }

        /// <summary>
        /// 要素のETag値
        /// </summary>
        public string ETag
        {
            get { return _eTag; }
            set
            {
                Contract.Requires(value!=null);
                _eTag = value;
            }
        }

        /// <summary>
        /// 要素の有効期限 (UTC)
        /// </summary>
        public DateTime ExpireAt { get; set; }

        /// <summary>
        /// 要素のコンテンツ
        /// </summary>
        public string Content
        {
            get { return _content; }
            set
            {
                Contract.Requires(value!=null);
                _content = value;
            }
        }
    }
}