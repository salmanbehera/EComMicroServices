using AutoMapper;
using Ecom_Microservice.CouponAPI.Data;
using Ecom_Microservice.CouponAPI.Model;
using Ecom_Microservice.CouponAPI.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_Microservice.CouponAPI.Controllers
{
    [Route("api/CouponAPI")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;
        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDTO();
            _mapper = mapper;
        }
        [HttpGet]
        public ResponseDTO Get() {
            try {
                IEnumerable<Coupon> objlist = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(objlist); ;

            }
            catch (Exception ex) {
            _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;   
        }
        [HttpGet("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(c => c.CouponId == id);
               
                _response.Result = _mapper.Map<CouponDTO>(obj); ;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetbyCode/{code}")]
        public ResponseDTO GetbyCode(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(c => c.CouponCode.ToLower() == code.ToLower());
                if (obj == null) { 
                _response.IsSuccess=false;
                }
                _response.Result = _mapper.Map<CouponDTO>(obj); ;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDTO Post([FromBody] CouponDTO coupondto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(coupondto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                 
                _response.Result = _mapper.Map<CouponDTO>(obj); ;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDTO Put([FromBody] CouponDTO coupondto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(coupondto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDTO>(obj); ;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public ResponseDTO Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(c => c.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDTO>(obj); ;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
    

}
