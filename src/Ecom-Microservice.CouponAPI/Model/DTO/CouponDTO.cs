﻿namespace Ecom_Microservice.CouponAPI.Model.DTO
{
    public class CouponDTO
    {
        public int CouponId { get; set; }

        public string CouponCode { get; set; }

        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
