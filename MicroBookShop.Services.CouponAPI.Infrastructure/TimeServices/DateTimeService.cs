using MicroBookShop.Services.CouponAPI.Application.Abstract.Services;

namespace MicroBookShop.Services.CouponAPI.Infrastructure.TimeServices;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}