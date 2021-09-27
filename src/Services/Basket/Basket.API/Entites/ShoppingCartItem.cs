using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entites
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        
        public string Color { get; set; }

        public decimal Price { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }
    }
}
