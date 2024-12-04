using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public static class Extensions
    {
        public static IServiceCollection AddExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);

            return services;
        }

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MSSQL") ?? throw new Exception("MSSQL IS NULL");

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
                connectionString,
                m => m.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)
                ));

            return services;
        }
    }
}
