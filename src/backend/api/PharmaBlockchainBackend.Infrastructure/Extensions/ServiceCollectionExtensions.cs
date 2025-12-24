using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PharmaBlockchainBackend.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PharmaBlockchainBackendDbContext>(options =>
                options.UseNpgsql(connectionString));

            //services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
