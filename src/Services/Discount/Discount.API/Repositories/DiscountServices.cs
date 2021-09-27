using Discount.API.Entities;
using System.Threading.Tasks;
using Discount.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Repositories
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
            await _db.Coupon.AddAsync(new Coupon
            {
                Amount = coupon.Amount,
                Description = coupon.Description,
                ProductName = coupon.ProductName
            });
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
