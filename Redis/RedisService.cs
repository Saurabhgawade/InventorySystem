using Newtonsoft.Json;
using StackExchange.Redis;
using System.CodeDom;

namespace projectDemo.Redis
{
    public class RedisService:IRedis
    {
        private readonly IDatabase _database;
        public RedisService(IConnectionMultiplexer multiplexer)
        {
            _database = multiplexer.GetDatabase();
        }
        public async Task<T> GetCacheData<T>(string key)
        {
            var result =await _database.StringGetAsync(key);
            if (!string.IsNullOrEmpty(result))
            {
                JsonConvert.DeserializeObject<T>(result);
            }
            return default;
        }

        public async Task<object> RemoveCacheData(string key)
        {
            var result = await _database.KeyExistsAsync(key);
            if (result)
            {
              return await _database.KeyDeleteAsync(key);
            }
            return false;
        }

        public async Task<bool> SetCacheData<T>(string key, T value, DateTimeOffset exptime)
        {
            TimeSpan currtime = exptime.DateTime.Subtract(DateTime.Now);

            return await _database.StringSetAsync(key, JsonConvert.SerializeObject(value), currtime);
        }
    }
}
