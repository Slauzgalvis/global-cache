namespace GobalCache.Repositories
{
    using GobalCache.Models;

    public interface ICacheRepository
    {
        bool Set(CacheKey cacheKey, int lifeTimeMinutes, string value);
        string? Get(CacheKey cacheKey);
        bool Remove(CacheKey cacheKey);
        long Increment(CacheKey cacheKey);
    }
}
