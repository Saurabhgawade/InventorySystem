namespace projectDemo.Redis
{
    public interface IRedis
    {
        Task<T> GetCacheData<T>(string key);

        Task<object> RemoveCacheData(string key);

        Task<bool> SetCacheData<T>(string key, T value, DateTimeOffset exptime);
    }
}
