using AutoMapper;
using MediatR;
using MicroBookShop.Services.CouponAPI.Application.Abstract.Repositories;

namespace MicroBookShop.Services.CouponAPI.Application.Coupon.Commands.CouponCreate
{
    public class CouponCreateCommandHandler(ICouponRepository _couponRepository, IMapper _mapper) : IRequestHandler<CouponCreateCommand, int>
    {
        private readonly ICouponRepository _couponRepository = _couponRepository;

        private readonly IMapper _mapper = _mapper;

        public async Task<int> Handle(CouponCreateCommand request, CancellationToken cancellationToken)
        {
            var coupon = _mapper.Map<Domain.Entities.Coupon>(request);
            var coupons = await _couponRepository.GetAllAsync(cancellationToken);
            var test =  await _couponRepository.CreateAsync(coupon, cancellationToken);

            return 1;
        }
    }
}
