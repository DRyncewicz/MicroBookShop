namespace MicroBookShop.Services.CouponAPI.Application.Dto;

public class CouponDto
{
    public int Id { get; set; }

    public string CouponCode { get; set; }

    public double DiscountAmount { get; set; }

    public int MinimalAmount { get; set; }
}
