using Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcServices 
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _clien;

        public DiscountGrpcServices(DiscountProtoService.DiscountProtoServiceClient clien)
        {
            _clien = clien ?? throw new ArgumentNullException(nameof(clien));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var req = new GetDiscountRequest { ProductName = productName };

            return await _clien.GetDiscountAsync(req);
        }
    }
}
