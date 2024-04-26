using MediatR;
using MicroBookShop.Services.CouponAPI.Application.Coupon.Commands.CouponCreate;
using MicroBookShop.Services.CouponAPI.Application.Coupon.Queries.CouponGetAll;
using MicroBookShop.Services.CouponAPI.Application.Dto.Common;
using MicroBookShop.Services.CouponAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace MicroBookShop.Services.CouponAPI.Controllers;

public class CouponController(IMediator _mediator) : BaseController
{
    private readonly IMediator _mediator = _mediator;

    private ResponseDto response = new ResponseDto();

    [HttpPost]
    public async Task<ActionResult<ResponseDto>> Create(CouponCreateCommand couponCreateCommand, CancellationToken cancellationToken)
    {
        try
        {
            var id = await _mediator.Send(couponCreateCommand, cancellationToken);
            response.Result = id;
            return Ok(response);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            return StatusCode(500, response);
        }
    }

    [HttpGet("GetByCode")]
    public async Task<ActionResult<ResponseDto>> GetByCode([FromQuery] CouponGetByCodeQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _mediator.Send(query, cancellationToken);
            response.Result = model;
            return Ok(response);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            return StatusCode(500, response);
        }

    }
}
