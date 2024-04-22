using MicroBookShop.Services.CouponAPI.Application.Abstract.Services;

namespace MicroBookShop.Services.CouponAPI.Infrastructure.TimeServices;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}