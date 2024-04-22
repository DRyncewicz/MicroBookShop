using MicroBookShop.Services.CouponAPI.Domain.Entities.Common;

namespace MicroBookShop.Services.CouponAPI.Domain.Entities;

public class Coupon : AuditableEntity
{
    public string CouponCode { get; set; }

    public double DiscountAmount { get; set; }

    public int MinimalAmount { get; set; }
}
