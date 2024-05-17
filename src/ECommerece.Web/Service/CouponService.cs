using ECommerece.Web.Models;
using ECommerece.Web.Service.IService;
using ECommerece.Web.Utility;

namespace ECommerece.Web.Service
{
    public class CouponService: ICouponService
    {
        private readonly IBaseService _baseservice;

        public CouponService(IBaseService baseService)
        {
            _baseservice = baseService;
        }
        public async Task<ResponseDTO?> CreateCouponsAsync(CouponDTO couponDTO)
        {
            return await _baseservice.SendAsync(new RequestDTO()
            {
                APIType = SD.ApiType.POST,
                Data = couponDTO,
                Url = SD.CouponApiBase + "api/CouponAPI"
            });
        }

        public async Task<ResponseDTO?> DeleteCouponsAsync(int id)
        {
            return await _baseservice.SendAsync(new RequestDTO()
            {
                APIType = SD.ApiType.DELETE,
                Url = SD.CouponApiBase + "api/CouponAPI/" + id
            });
        }

        public async Task<ResponseDTO?> GetAllCouponsAsync()
        {
            return await _baseservice.SendAsync(new RequestDTO()
            {
                APIType = SD.ApiType.GET,
                Url = SD.CouponApiBase + "api/CouponAPI"
            });
        }

        public async Task<ResponseDTO?> GetCouponByIdAsync(int id)
        {
            return await _baseservice.SendAsync(new RequestDTO()
            {

                APIType = SD.ApiType.GET,
                Url = SD.CouponApiBase + "api/CouponAPI/" + id
            });
        }

        public async Task<ResponseDTO?> GetCouponsAsync(string couponcode)
        {
            return await _baseservice.SendAsync(new RequestDTO()
            {

                APIType = SD.ApiType.GET,
                Url = SD.CouponApiBase + "api/CouponAPI/GetbyCode/" + couponcode
            });
        }

        public async Task<ResponseDTO?> UpdateCouponsAsync(CouponDTO couponDTO)
        {
            return await _baseservice.SendAsync(new RequestDTO()
            {
                APIType = SD.ApiType.PUT,
                Data = couponDTO,
                Url = SD.CouponApiBase + "api/CouponAPI"
            });
        }
    }
}
