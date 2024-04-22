using MicroBookShop.Services.CouponAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroBookShop.Services.CouponAPI.Infrastructure.Configuration;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.Property(p => p.CouponCode).IsRequired().HasMaxLength(15);
        builder.Property(p => p.DiscountAmount).IsRequired();
        builder.Property(p => p.MinimalAmount).IsRequired();
    }
}
