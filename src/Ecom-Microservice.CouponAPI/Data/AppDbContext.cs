using Ecom_Microservice.CouponAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecom_Microservice.CouponAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)  
        {
            
        }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>()
                .Property(c => c.DiscountAmount)
                .HasColumnType("decimal(18, 2)");
        }
    }
    
}
