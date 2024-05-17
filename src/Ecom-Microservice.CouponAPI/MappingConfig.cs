using AutoMapper;
using Ecom_Microservice.CouponAPI.Model;
using Ecom_Microservice.CouponAPI.Model.DTO;

namespace Ecom_Microservice.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() { 
        var mappingconfig=new MapperConfiguration(config => {
            config.CreateMap<CouponDTO, Coupon>();
            config.CreateMap<Coupon, CouponDTO>();
        });
            return mappingconfig;
        }
    }
}
