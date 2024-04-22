using IdentityModel;
using MicroBookShop.Services.CouponAPI.Application.Abstract.Services;
using Microsoft.AspNetCore.Http;

namespace MicroBookShop.Services.CouponAPI.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    public string? UserId { get; set; }

    public bool IsAuthenticated { get; set; }

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        var userId = httpContextAccessor.HttpContext?.User?.FindFirst(JwtClaimTypes.Id).Value;

        UserId = userId;

        IsAuthenticated = !string.IsNullOrEmpty(userId);
    }
}