using MediatR;
using MicroBookShop.Services.CouponAPI.Application.Dto.Coupon;

namespace MicroBookShop.Services.CouponAPI.Application.Coupon.Queries.CouponGetAll;

public class CouponGetByCodeQuery : IRequest<CouponDto>
{
    public string CouponCode { get; set; }
}
