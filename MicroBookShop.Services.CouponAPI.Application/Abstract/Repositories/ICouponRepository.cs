using MicroBookShop.Services.CouponAPI.Domain.Entities;

namespace MicroBookShop.Services.CouponAPI.Application.Abstract.Repositories;

public interface ICouponRepository 
{
    Task<int> CreateAsync(Coupon coupon, CancellationToken ct);

    Task<IEnumerable<Coupon>> GetAllAsync(CancellationToken ct);
}
