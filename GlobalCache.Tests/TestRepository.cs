namespace GlobalCache.Tests
{
    using GobalCache.Models;
    using GobalCache.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StackExchange.Redis;
    using System;

    [TestClass]
    public class TestRepository
    {
        private readonly RedisCacheRepository _redisCacheRepository;
        private readonly CacheKey _cacheKey;
        public TestRepository()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
            _redisCacheRepository = new(redis);

            _cacheKey = new()
            {
                BookingSiteId = 999999999,
                Method = "OW",
                DictionaryName = "Test",
                Key = "TST"
            };
        }

        [TestMethod]
        public void Test_Get_Set()
        {
            string value = "BestTeam";
            _redisCacheRepository.Set(_cacheKey, 1, value);

            string? responseValue = _redisCacheRepository.Get(_cacheKey);

            Assert.AreEqual(responseValue, value);
            _redisCacheRepository.Remove(_cacheKey);
        }

        [TestMethod]
        public void Test_Increment()
        {
            for (int i = 1; i < 10; i++)
            {
                long number = _redisCacheRepository.Increment(_cacheKey);
                Assert.AreEqual(number, i);
            }

            _redisCacheRepository.Remove(_cacheKey);
        }

        [TestMethod]
        public void Test_Remove()
        {
            CacheKey cacheKey = new();
            cacheKey.BookingSiteId = new Random().Next();
            cacheKey.Method = "OW";
            cacheKey.DictionaryName = "Test";
            cacheKey.Key = "Remove";
        
            Assert.IsFalse(_redisCacheRepository.Remove(_cacheKey));
            
            _redisCacheRepository.Set(_cacheKey, 1, "BestTeams");

            Assert.IsTrue(_redisCacheRepository.Remove(_cacheKey));
        }
    }
}