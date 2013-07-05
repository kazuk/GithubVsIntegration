using System;

namespace GithubClient
{
    public class CacheEntry
    {
        public string ETag { get; set; }
        public string Content { get; set; }
        public string RequestUri { get; set; }

        public DateTime ExpireAt { get; set; }
    }
}