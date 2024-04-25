using MediatR;
using MicroBookShop.Services.CouponAPI.Application.Coupon.Commands.CouponCreate;
using MicroBookShop.Services.CouponAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace MicroBookShop.Services.CouponAPI.Controllers;

public class CouponController(IMediator _mediator) : BaseController
{
    private readonly IMediator _mediator = _mediator;
    [HttpPost]
    public async Task<ActionResult<int>> Create(CouponCreateCommand couponCreateCommand, CancellationToken cancellationToken)
    {
        await _mediator.Send(couponCreateCommand, cancellationToken);

        return Created();
    }
}
