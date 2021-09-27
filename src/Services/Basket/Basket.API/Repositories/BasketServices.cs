using Basket.API.Data;
using Basket.API.Entites;
using Microsoft.EntityFrameworkCore;
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
        private readonly BasketContext db;

        public BasketServices(IDistributedCache redis, BasketContext db)
        {
            this.db = db;
        }

        public async Task Delete(string userName)
        {
            var cart = await GetBasket(userName);
            db.Remove(cart);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            return await db.ShoppingCart.SingleOrDefaultAsync(s => s.UserName == userName);
        }

        public async Task<ShoppingCart> Update(ShoppingCart cart)
        {
            db.ShoppingCart.Update(cart);
            return await GetBasket(cart.UserName);
        }
    }
}
