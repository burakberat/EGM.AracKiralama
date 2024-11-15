using Castle.DynamicProxy;
using Infra.BL.Abstracts;
using Infra.BL.Concretes;
using Infra.DAL.Abstracts;
using Infra.DAL.Context;
using INfra.DAL.Concretes;
using Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEGMLog(this IServiceCollection services, string dbConettion)
        {
            services.AddDbContext<LogDbContext>(options =>
            {
                options.UseSqlServer(dbConettion);
            });

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogService, LogService>();

            return services;
        }

        public static IServiceCollection AddProxiedServices(this IServiceCollection services, ProxyGenerator proxyGenerator)
        {
            var list = services.Where(x => x.Lifetime == ServiceLifetime.Scoped && x.ServiceType.Name.EndsWith("Service") && !x.ServiceType.FullName.StartsWith("Infra.") && !x.ServiceType.FullName.StartsWith("Microsoft")).ToList();

            foreach (var item in list)
            {
                var implementationType = item.ImplementationType;
                services.Remove(item);

                services.AddScoped(serviceProvider =>
                {
                    var target = ActivatorUtilities.CreateInstance(serviceProvider, implementationType);
                    var interceptor = serviceProvider.GetRequiredService<CachingInterceptor>();
                    return proxyGenerator.CreateClassProxyWithTarget(implementationType, target, interceptor);
                });
            }
            return services;
        }
    }
}