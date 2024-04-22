using MicroBookShop.Services.CouponAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroBookShop.Services.CouponAPI.Infrastructure.ServiceRegistrations;

public static class ServiceRegistration
{
    public static IServiceCollection AddInrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<CouponDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}
