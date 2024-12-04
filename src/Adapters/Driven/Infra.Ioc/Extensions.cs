using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public static class Extensions
    {
        public static IServiceCollection AddExtensions(this IServiceCollection services)
        {
            return services;
        }
    }
}
