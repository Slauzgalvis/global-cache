namespace GlobalCache.Tests
{
    using GobalCache.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StackExchange.Redis;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
            var db = redis.GetDatabase();
            RedisCacheRepository redisCacheRepository = new RedisCacheRepository(redis);

            int bookingSiteId = 55;
            string method = "OW";
            int lifeTime = 1;
            string dictionaryName = "Elektrit";
            string key = "IsAGoodTeam";
            string value = "dalykai";

            redisCacheRepository.SetValue(bookingSiteId, method, dictionaryName, key, lifeTime, value);

            string responseValue = redisCacheRepository.GetValue(bookingSiteId, method, dictionaryName, key);

            Assert.AreEqual(responseValue, value);
        }
        [TestMethod]
        public void TestMethod2()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
            var db = redis.GetDatabase();
            RedisCacheRepository redisCacheRepository = new RedisCacheRepository(redis);

            int bookingSiteId = 55;
            string method = "OW";
            int lifeTime = 0;
            string dictionaryName = "Elektrit";
            string key = "IsAGoodTeam";
            string value = "dalykai";

            redisCacheRepository.SetValue(bookingSiteId, method, dictionaryName, key, lifeTime, value);

            string responseValue = redisCacheRepository.GetValue(bookingSiteId, method, dictionaryName, key);

            Assert.AreEqual(responseValue, value);
        }
    }
}