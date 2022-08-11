using Microsoft.Extensions.DependencyInjection;
using RedisService.Service;

namespace RedisService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRedisServer(this IServiceCollection services)
        {

            services.AddSingleton<RedisServer>();
            services.AddScoped<IRedisService, Service.RedisService>();

            return services;
        }
    }
}
