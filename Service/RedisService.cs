using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RedisService.Service
{
    public class RedisService : IRedisService
    {
        private readonly RedisServer _redisServer;

        public RedisService(RedisServer redisServer)
        {
            _redisServer = redisServer;
        }

        public async Task<bool> Any(string Key)
        {
            return await _redisServer.Database.KeyExistsAsync(Key);
        }
        public async Task<bool> Delete(string Key)
        {
            return await _redisServer.Database.KeyDeleteAsync(Key);
        }
        public async Task<bool> Set(string Key, object obj)
        {
            return await _redisServer.Database.StringSetAsync(Key, JsonConvert.SerializeObject(obj));
        }
        public async Task<string> Get(string Key)
        {
            return await _redisServer.Database.StringGetAsync(Key);

        }
    }
}
