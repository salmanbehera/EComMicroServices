using ECommerece.Web.Models;

namespace ECommerece.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestdto);
    }
}
