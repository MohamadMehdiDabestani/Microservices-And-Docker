using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Discount.Grpc.Entities;
using Discount.Grpc.Data;
using Microsoft.EntityFrameworkCore;
namespace Discount.Grpc.Repositories
{
    public class DiscountServices : IDiscountServices
    {
        private readonly DiscountContext _db;

        public DiscountServices(DiscountContext db)
        {
            _db = db;
        }
        public async Task<bool> CreateCoupon(Coupon coupon)
        {
            await _db.Coupon.AddAsync(coupon);
            return await _db.SaveChangesAsync() > 0;
        }


        public async Task<bool> DeleteCoupon(string productname)
        {
            var coupon = await GetCoupon(productname);
            if (coupon != null)
            {
                _db.Coupon.Remove(coupon);
                return await _db.SaveChangesAsync() > 0;
            }
            else
                return false;
        }

        public async Task<Coupon> GetCoupon(string productname)
        {
            return await _db.Coupon.SingleOrDefaultAsync(p => p.ProductName == productname);
        }

        public async Task<bool> UpdateCoupon(Coupon coupon)
        {
            _db.Coupon.Update(coupon);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
