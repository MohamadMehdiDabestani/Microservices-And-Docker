using Basket.API.Entites;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketServices _basket;

        public BasketController(IBasketServices basket)
        {
            _basket = basket;
        }
        [HttpGet("{name}" , Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart) , (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBasket(string name)
        {
            var basket = await _basket.GetBasket(name);
            return Ok(basket ?? new ShoppingCart(name));
        }
        [HttpPut]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] ShoppingCart shoppingCart)
        {
            var basket = await _basket.Update(shoppingCart);
            return Ok(basket);
        }
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string name)
        {
            await _basket.Delete(name);
            return Ok();
        }
    }
}
