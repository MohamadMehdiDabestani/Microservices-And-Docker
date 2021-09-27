using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entites
{
    public class ShoppingCart
    {
        public string UserName { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart()
        {

        }
        public ShoppingCart(string name)
        {
            UserName = name;
        }

        public decimal TotalPrice 
        { 
            get {
                decimal total = 0;
                foreach(var i in Items)
                {
                    total = i.Price * i.Quantity;
                }
                return total;
            }
        }

    }
}
