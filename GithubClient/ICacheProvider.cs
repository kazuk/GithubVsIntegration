namespace GithubClient
{
    public interface ICacheProvider
    {
        CacheEntry GetEntry(string requestUri);
        void RemoveEntry(string requestUri);
        void UpdateEntry(CacheEntry cacheEntry);
        void CreateEntry(CacheEntry cacheEntry);
    }
}