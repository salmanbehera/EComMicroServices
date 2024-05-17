using System.ComponentModel.DataAnnotations;

namespace Ecom_Microservice.CouponAPI.Model
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string? CouponCode { get; set; }
        [Required]
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
