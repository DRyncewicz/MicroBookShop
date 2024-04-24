using System.Text.Json;

namespace MicroBookShop.Services.CouponAPI.Domain.Errors;

public class ErrorDetails : BaseDetails
{

    public ErrorDetails() : base()
    {
    }
    public ErrorDetails(int statusCode, string message) : base(message) => StatusCode = statusCode;

    public int StatusCode { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this, GetType());
}