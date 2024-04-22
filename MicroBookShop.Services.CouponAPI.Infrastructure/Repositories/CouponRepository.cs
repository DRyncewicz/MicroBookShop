using MicroBookShop.Services.CouponAPI.Application.Abstract.Repositories;
using MicroBookShop.Services.CouponAPI.Domain.Entities;

namespace MicroBookShop.Services.CouponAPI.Infrastructure.Repositories;

public class CouponRepository(IBaseRepository _baseRepository) : ICouponRepository
{
    private readonly IBaseRepository _baseRepository = _baseRepository;

    public async Task<int> CreateAsync(Coupon coupon, CancellationToken ct)
    {
        await _baseRepository.AddAsync(coupon, ct);
        var id = await _baseRepository.SaveAsync(ct);

        return id;
    }

    public async Task<IEnumerable<Coupon>> GetAllAsync(CancellationToken ct)
    {
        return _baseRepository.GetAll<Coupon>(); 
    }
}
