using AutoMapper;

namespace MicroBookShop.Services.CouponAPI.Application.Mapping;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());
}
