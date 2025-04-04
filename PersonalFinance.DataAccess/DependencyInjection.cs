using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinance.DataAccess.Contexts;

namespace PersonalFinance.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PersonalFinanceContext>(options =>
                options.UseSqlServer(defaultConnectionString));

            return services;
        }
    }
}