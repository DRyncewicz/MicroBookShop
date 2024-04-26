using MicroBookShop.Web.Models;

namespace MicroBookShop.Web.Services.IService;

public interface IBaseService
{
    Task<ResponseDto?> SendAsync(RequestDto requestDto);
}
