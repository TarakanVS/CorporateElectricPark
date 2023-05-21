using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Net.NetworkInformation;

namespace Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly));

            return services;
        }
    }
}