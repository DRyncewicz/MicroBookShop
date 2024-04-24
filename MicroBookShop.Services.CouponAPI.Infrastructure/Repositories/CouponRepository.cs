using MicroBookShop.Services.CouponAPI.Application.Abstract.Repositories;
using MicroBookShop.Services.CouponAPI.Domain.Entities;

namespace MicroBookShop.Services.CouponAPI.Infrastructure.Repositories;

public class CouponRepository(IBaseRepository _baseRepository) : ICouponRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task<int> CreateAsync(Coupon coupon, CancellationToken ct = default)
    {
        await _baseRepository.AddAsync(coupon, ct);

        return await _baseRepository.SaveAsync(ct);
    }

    public async Task<IEnumerable<Coupon>> GetAllAsync(CancellationToken ct = default)
    {
        return _baseRepository.GetAll<Coupon>(); 
    }
}
