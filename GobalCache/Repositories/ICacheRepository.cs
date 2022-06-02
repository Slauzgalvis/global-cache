namespace GobalCache.Repositories
{
    using GobalCache.Models;

    public interface ICacheRepository
    {
        void SetValue(int bookingSiteId, string method, string dictionaryName, string key, int lifeTimeMinutes, string value);
        string GetValue(int bookingSiteId, string method, string dictionaryName, string key);
    }
}
