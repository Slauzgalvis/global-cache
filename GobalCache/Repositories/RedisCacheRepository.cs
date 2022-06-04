namespace GobalCache.Repositories
{
    using GobalCache.Models;
    using StackExchange.Redis;

    public class RedisCacheRepository : ICacheRepository
    {
        private readonly IDatabase _db;

        public RedisCacheRepository(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public bool Set(CacheKey cacheKey, int lifeTimeMinutes, string value)
        {
            try
            {
                return _db.StringSet(cacheKey.GetRedisKey(), value, new TimeSpan(0, lifeTimeMinutes, 0));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string? Get(CacheKey cacheKey)
        {
            try
            {
                string value = _db.StringGet(cacheKey.GetRedisKey());

                return value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Remove(CacheKey cacheKey)
        {
            try
            {
                return _db.KeyDelete(cacheKey.GetRedisKey());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public long Increment(CacheKey cacheKey)
        {
            try
            {
                return _db.StringIncrement(cacheKey.GetRedisKey());
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
