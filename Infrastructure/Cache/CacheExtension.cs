using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Cache
{
    public static class CacheExtension
    {
        public static void AddInRedisCache(this IServiceCollection services, RedisConfiguration redisConfiguration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConfiguration.Configuration;
                options.InstanceName = redisConfiguration.InstanceName;
            });

            services.AddSingleton<ICacheService, RedisCacheService>();
        }

        public static void AddInMemoryCache(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, MemoryCacheService>();
        }
    }
}
