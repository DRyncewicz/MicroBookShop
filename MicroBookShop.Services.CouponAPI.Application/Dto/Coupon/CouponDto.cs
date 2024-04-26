using AutoMapper;
using MicroBookShop.Services.CouponAPI.Application.Mapping;
using MicroBookShop.Services.CouponAPI.Domain.Entities;

namespace MicroBookShop.Services.CouponAPI.Application.Dto.Coupon;

public class CouponDto : IMapFrom<Domain.Entities.Coupon>
{
    public int Id { get; set; }

    public string CouponCode { get; set; }

    public double DiscountAmount { get; set; }

    public int MinimalAmount { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Coupon, CouponDto>();
    }
}
