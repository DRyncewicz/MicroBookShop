namespace MicroBookShop.Services.CouponAPI.Application.Abstract.Services;

public interface ICurrentUserService
{
    string UserId { get; set; }

    bool IsAuthenticated { get; set; }
}
