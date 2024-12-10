using Application.Abstractions;
using Application.UseCases;
using Infra.Data.Abstractions;
using Infra.Data.Context;
using Infra.Data.Repositories;
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
            services.AddAdaptors();

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

        public static IServiceCollection AddAdaptors(this IServiceCollection services)
        {
            services.AddScoped<IClientMapper, ClientMapper>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICreateClientUseCase, CreateClientUseCase>();

            return services;
        }
    }
}
