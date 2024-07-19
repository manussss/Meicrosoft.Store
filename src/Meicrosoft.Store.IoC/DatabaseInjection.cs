using Meicrosoft.Store.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Store.IoC
{
    public static class DatabaseInjection
    {
        public static void AddDatabaseInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(configuration.GetConnectionString("ProductConnection")));
        }
    }
}
