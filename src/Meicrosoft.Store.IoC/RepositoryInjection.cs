using Meicrosoft.Store.Application.Queries;
using Meicrosoft.Store.Application.Queries.Interface;
using Meicrosoft.Store.Domain.ProductsAggregate;
using Meicrosoft.Store.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Store.IoC
{
    public static class RepositoryInjection
    {
        public static void AddRepositoriesInjection(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductQuery, ProductQuery>();
        }
    }
}
