using Infra.BL.Abstracts;
using Infra.BL.Concretes;
using Infra.DAL.Abstracts;
using Infra.DAL.Context;
using INfra.DAL.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEgmLog(this IServiceCollection services, string dbConnection)
        {
            services.AddDbContext<LogDbContext>(options =>
            {
                options.UseSqlServer(dbConnection);
            });
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ILogRepository, LogRepository>();

            return services;
        }
    }
}
