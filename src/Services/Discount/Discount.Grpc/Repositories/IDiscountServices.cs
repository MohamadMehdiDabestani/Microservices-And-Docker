using Discount.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public interface IDiscountServices
    {
        Task<Coupon> GetCoupon(string productname);

        Task<bool> UpdateCoupon(Coupon coupon);
        
        Task<bool> CreateCoupon(Coupon coupon);
        
        Task<bool> DeleteCoupon(string productname);
    }
}
