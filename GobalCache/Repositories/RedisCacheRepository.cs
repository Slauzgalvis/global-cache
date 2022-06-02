namespace GobalCache.Repositories
{
    using GobalCache.Models;
    using StackExchange.Redis;
    using System.Text.Json;

    public class RedisCacheRepository : ICacheRepository
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisCacheRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public void SetValue(int bookingSiteId, string method, string dictionaryName, string key, int lifeTimeMinutes, string value)
        {
            string redisKey = GenerateKey(bookingSiteId, method, dictionaryName, key);

            var db = _redis.GetDatabase();

            db.StringSet(redisKey, value, new TimeSpan(0, lifeTimeMinutes, 0));
        }

        public string GetValue(int bookingSiteId, string method, string dictionaryName, string key)
        {
            var db = _redis.GetDatabase();

            string redisKey = GenerateKey(bookingSiteId, method, dictionaryName, key);

            var value = db.StringGet(redisKey);

            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }

            return "";
        }

        private string GenerateKey(int bookingSiteId, string method, string dictionaryName, string key)
        {
            return string.Format("{0}_{1}_{2}_{3}", bookingSiteId, method, dictionaryName, key);
        }

    }
}
