using System.Threading.Tasks;

namespace RedisService.Service
{
    public interface IRedisService
    {
        Task<bool> Any(string Key);
        Task<bool> Delete(string Key);
        Task<bool> Set(string Key, object obj);
        Task<string> Get(string Key);
    }
}
