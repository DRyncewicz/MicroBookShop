using AutoMapper;
using MediatR;
using MicroBookShop.Services.CouponAPI.Application.Abstract.Repositories;
using MicroBookShop.Services.CouponAPI.Application.Dto.Coupon;

namespace MicroBookShop.Services.CouponAPI.Application.Coupon.Queries.CouponGetAll;

public class CouponGetByCodeQueryHandler(ICouponRepository _couponRepository, IMapper _mapper) : IRequestHandler<CouponGetByCodeQuery, CouponDto>
{
    private readonly ICouponRepository _couponRepository = _couponRepository;

    private readonly IMapper _mapper = _mapper;

    public async Task<CouponDto> Handle(CouponGetByCodeQuery request, CancellationToken cancellationToken)
    {
        var coupons = await _couponRepository.GetAllAsync(cancellationToken);
        var couponByCode = coupons.FirstOrDefault(x => x.CouponCode == request.CouponCode);

        return _mapper.Map<CouponDto>(couponByCode);  
    }
}
