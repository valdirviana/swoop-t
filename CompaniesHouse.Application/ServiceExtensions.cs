using CompaniesHouse.Application.Features;
using CompaniesHouse.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CompaniesHouse.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
        }
    }
}
