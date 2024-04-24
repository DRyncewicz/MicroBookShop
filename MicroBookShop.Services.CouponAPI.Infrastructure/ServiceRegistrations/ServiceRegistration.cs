using MicroBookShop.Services.CouponAPI.Application.Abstract.Repositories;
using MicroBookShop.Services.CouponAPI.Application.Abstract.Services;
using MicroBookShop.Services.CouponAPI.Infrastructure.Abstract;
using MicroBookShop.Services.CouponAPI.Infrastructure.Context;
using MicroBookShop.Services.CouponAPI.Infrastructure.Repositories;
using MicroBookShop.Services.CouponAPI.Infrastructure.Repositories.Common;
using MicroBookShop.Services.CouponAPI.Infrastructure.Services;
using MicroBookShop.Services.CouponAPI.Infrastructure.TimeServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MicroBookShop.Services.CouponAPI.Infrastructure.ServiceRegistrations;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.TryAddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));
        services.AddScoped<IBaseRepository, BaseRepository>();
        services.AddScoped<ICouponRepository, CouponRepository>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IDateTimeService, DateTimeService>();

        return services;
    }
}
