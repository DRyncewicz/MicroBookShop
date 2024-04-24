namespace MicroBookShop.Services.CouponAPI.Application.Abstract.Repositories;

public interface ICouponRepository 
{
    Task<int> CreateAsync(Domain.Entities.Coupon coupon, CancellationToken ct);

    Task<IEnumerable<Domain.Entities.Coupon>> GetAllAsync(CancellationToken ct);
}
