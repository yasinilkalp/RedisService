using Microsoft.Extensions.DependencyInjection;
using RedisService.Service;

namespace RedisService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMailSender(this IServiceCollection services)
        {

            services.AddSingleton<RedisServer>();
            services.AddScoped<IRedisService, Service.RedisService>();

            return services;
        }
    }
}
