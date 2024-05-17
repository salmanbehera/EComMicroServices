using ECommerece.Web.Models;
using ECommerece.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerece.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponservice;
        public CouponController(ICouponService couponservice)
        {
            _couponservice = couponservice;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDTO>? list = new();
            ResponseDTO? responsedto =await _couponservice.GetAllCouponsAsync();
            if (responsedto != null && responsedto.IsSuccess)
            {
                list= JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(responsedto.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> CreateCoupon() {
        return View();
        }
		[HttpPost]
		public async Task<IActionResult> CreateCoupon(CouponDTO model)
		{
			if (ModelState.IsValid)
			{
				ResponseDTO? response = await _couponservice.CreateCouponsAsync(model);
				if (response != null && response.IsSuccess)
				{
					TempData["success"] = "Coupon Create Successfully";

					return RedirectToAction(nameof(CouponIndex));
				}
				else
				{
					TempData["error"] = response.Message;
				}
			}
			return View(model);
		}

		public async Task<IActionResult> DeleteCoupon(int couponid)
		{
			ResponseDTO? response = await _couponservice.GetCouponByIdAsync(couponid);
			if (response != null && response.IsSuccess)
			{
				TempData["success"] = "Coupon Delete Successfully";

				CouponDTO? model = JsonConvert.DeserializeObject<CouponDTO>(Convert.ToString(response.Result));
				return View(model);
			}
			else
			{
				TempData["error"] = response.Message;
			}
			return NotFound();
		}
		[HttpPost]
		 
		public async Task<IActionResult> DeleteCoupon(CouponDTO coupondto)
		{
			ResponseDTO? response = await _couponservice.DeleteCouponsAsync(coupondto.CouponId);
			if (response != null && response.IsSuccess)
			{
				return RedirectToAction(nameof(CouponIndex));
			}
			else
			{
				TempData["error"] = response.Message;
			}
			return View(coupondto);
		}

	}
}
