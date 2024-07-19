using MediatR;
using Meicrosoft.Store.Application.Commands.Create;
using Meicrosoft.Store.Application.Commands.Delete;
using Meicrosoft.Store.Application.Commands.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Store.IoC
{
    public static class MediatorInjection
    {
        public static void AddMediatorInjection(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateProductCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteProductCommand).Assembly));
        }
    }
}
