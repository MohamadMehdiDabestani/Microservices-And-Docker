using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Discount.Grpc.Services
{
    public class DiscountServicesGrpc : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountServices _discount;
        private readonly IMapper _mapper;
        public DiscountServicesGrpc(IDiscountServices discount, IMapper mapper)
        {
            _discount = discount ?? throw new ArgumentNullException(nameof(discount));
            _mapper = mapper;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _discount.GetCoupon(request.ProductName);

            if(coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with productname '{request.ProductName}' is not found"));
            }
            var res = _mapper.Map<CouponModel>(coupon);
            return res;
        }
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupn);

            await _discount.CreateCoupon(coupon);

            var res = _mapper.Map<CouponModel>(coupon);

            return res;
        }

        public override async Task<DeleteResponse> DeleteDiscount(DeleteRequest request, ServerCallContext context)
        {
            var res = await _discount.DeleteCoupon(request.ProductName);

            return new DeleteResponse
            {
                Res = res
            };
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupn);

            var res = await _discount.UpdateCoupon(coupon);
            if (res)
                return _mapper.Map<CouponModel>(coupon);

            throw new RpcException(new Status(StatusCode.NotFound, $"Discount with productname '{request.Coupn.ProductName}' is not found"));
        }
    }
}
