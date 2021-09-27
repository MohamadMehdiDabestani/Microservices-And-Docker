using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountServices _discount;

        public DiscountController(IDiscountServices discount)
        {
            _discount = discount;
        }
        [HttpGet("{productname}" , Name ="GetDiscount")]
        [ProducesResponseType(typeof(Coupon) , (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDiscount(string productname)
        {
            var res = await _discount.GetCoupon(productname);
            return Ok(res);
        }
        [HttpPost(Name = "AddDiscount")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddDiscount([FromBody] Coupon coupon)
        {
            var res = await _discount.CreateCoupon(coupon);
            return Ok(res);
        }
        [HttpPut(Name = "UpdateDiscount")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDiscount([FromBody] Coupon coupon)
        {
            var res = await _discount.UpdateCoupon(coupon);
            return Ok(res);
        }
        [HttpDelete("{productname}",Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDiscount(string productname)
        {
            var res = await _discount.DeleteCoupon(productname);
            return Ok(res);
        }
    }
}
