using Discount.Grpc.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> opt):base(opt)
        {

        }
        public DbSet<Coupon> Coupon { get; set; }
    }
}
