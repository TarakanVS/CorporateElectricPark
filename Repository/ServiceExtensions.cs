using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Repository
{
    public static class ServiceExtensions
    {
        public static void RegisterRepos(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(IRepository<>), typeof(ElectricCarParkRepository<>));
        }
    }
}
