using ECommerece.Web.Models;

namespace ECommerece.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO?> GetCouponsAsync(string couponcode);
        Task<ResponseDTO?> GetAllCouponsAsync();
        Task<ResponseDTO?> GetCouponByIdAsync(int id);
        Task<ResponseDTO?> CreateCouponsAsync(CouponDTO couponDTO);
        Task<ResponseDTO?> UpdateCouponsAsync(CouponDTO couponDTO);
        Task<ResponseDTO?> DeleteCouponsAsync(int id);
    }
}
