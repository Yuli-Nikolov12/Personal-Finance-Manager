using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PersonalFinance.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}