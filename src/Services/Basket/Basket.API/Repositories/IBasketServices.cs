using Basket.API.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface IBasketServices
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> Update(ShoppingCart cart);
        Task Delete(string userName);

    }
}
