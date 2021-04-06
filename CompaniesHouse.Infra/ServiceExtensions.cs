using CompaniesHouse.Application.Interfaces;
using CompaniesHouse.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CompaniesHouse.Application
{
    public static class ServiceExtensions
    {
        public static void AddInfraLayer(this IServiceCollection services)
        {
            services.AddTransient<IHttpClientServices, HttpClientServices>();
        }
    }
}
