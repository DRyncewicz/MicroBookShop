namespace MicroBookShop.Services.CouponAPI.Domain.Errors;

public class BaseDetails
{
    public string? Message { get; set; } = null;

    public BaseDetails()
    {
    }

    public BaseDetails(string? message) : this() => Message = message;
}