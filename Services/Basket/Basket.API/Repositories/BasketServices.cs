using Basket.API.Entites;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketServices : IBasketServices
    {
        private readonly IDistributedCache _redis;

        public BasketServices(IDistributedCache redis)
        {
            _redis = redis;
        }

        public async Task Delete(string userName)
        {
            await _redis.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redis.GetStringAsync(userName);
            if(string.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> Update(ShoppingCart cart)
        {
            await _redis.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));

            return await GetBasket(cart.UserName);
        }
    }
}
