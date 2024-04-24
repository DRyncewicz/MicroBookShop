using FluentValidation;

namespace MicroBookShop.Services.CouponAPI.Application.Coupon.Commands.CouponCreate;

public class CouponCreateCommandValidation : AbstractValidator<CouponCreateCommand>
{
    public CouponCreateCommandValidation()
    {
        RuleFor(p => p.CouponCode).NotEmpty().WithMessage("Coupon code is required")
            .Length(10, 15).WithMessage("Coupon code should have between 10 and 15 chars");
        RuleFor(p => p.MinimalAmount).NotEmpty().WithMessage("Minimal amount is required");
        RuleFor(p => p.DiscountAmount).NotEmpty().WithMessage("Discount amount is required");
    }
}
