using MediatR;
using Meicrosoft.Store.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Store.IoC
{
    public static class MediatorInjection
    {
        public static void AddMediatorInjection(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommand).Assembly));
        }
    }
}
