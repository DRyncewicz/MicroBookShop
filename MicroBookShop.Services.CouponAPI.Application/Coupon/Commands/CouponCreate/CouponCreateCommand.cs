using AutoMapper;
using MediatR;
using MicroBookShop.Services.CouponAPI.Application.Mapping;

namespace MicroBookShop.Services.CouponAPI.Application.Coupon.Commands.CouponCreate;

public class CouponCreateCommand : IRequest<int>, IMapFrom<Domain.Entities.Coupon>
{
    public string CouponCode { get; set; }

    public double DiscountAmount { get; set; }

    public int MinimalAmount { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CouponCreateCommand, Domain.Entities.Coupon>();
    }
}
